using Customer_Relationship_Management.Contracts.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Customer_Relationship_Management.Service;

public class UserService
{
    private readonly CustomerDbContext _context;
    private readonly IMapper _mapper;
    private readonly HttpContext _httpContext;
    

    public UserService(CustomerDbContext context, IMapper mapper, IHttpContextAccessor accessor)
    {
        _context = context;
        _mapper = mapper;
        if (accessor.HttpContext is null) throw new ArgumentException(nameof(accessor.HttpContext));
        _httpContext = accessor.HttpContext;
    }

    public async Task<User> SignUpAsync(UserRegisterDto userDto)
    {
        var user = await _context.Users.AsNoTracking().Where(x => x.Email == userDto.Email).ToListAsync();
        if (user is not null) throw new Exception("user already exists");
        var res = _mapper.Map<User>(userDto);
        await _context.Users.AddAsync(res);
        await _context.SaveChangesAsync();
        return res;
    }


    private Task SignInWithHttpContext(RoleEnum role, int id, string email)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Email, email),
            new(ClaimTypes.NameIdentifier, id.ToString()),
            new(ClaimTypes.Role, role.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, "cookie");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        return _httpContext.SignInAsync(claimsPrincipal);
    }

    public async Task<List<UserReplyDto>> GetAllUsersAsync()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
        var res = _mapper.Map<List<UserReplyDto>>(users);
        return res;
       
    }

    public async Task<UserReplyDto> GetDataUserAsync(int id)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<UserReplyDto>(user);
    }

    public async Task<User> DeleteUserByIdAsync(long id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null)
            return null!;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> BlockUserAsync(long userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null) throw new Exception("Not Found");
        if (user.DateBlock == null ) throw new Exception("the user is already blocked");
        user.DateBlock = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserReplyDto> ChangeUserRoleAsync(long userId, RoleEnum newRole)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user is null) throw new Exception("Not Found");
        if (user.Role == newRole)
            user.Role = newRole;
        await _context.SaveChangesAsync();

        return _mapper.Map<UserReplyDto>(user);
    }


   
}
