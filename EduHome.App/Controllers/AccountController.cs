using EduHome.Core.DTOS.Account;
using EduHome.Core.Entities;
using EduHome.Data.DAl;
using EduHomeServices.ExternalServices.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Security.Principal;

namespace EduHome.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly EduHomeDbContext _context;

        //readonly RoleManager<IdentityRole> _roleManager;
        //readonly UserManager<User> _userManager;
        //readonly SignInManager<User> _signInManager;
        //readonly IEmailService _emailService;
        //readonly IWebHostEnvironment _webHostEnvironment;
        //public AccountController(EduHomeDbContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService, IWebHostEnvironment webHostEnvironment)
        //{
        //    _context = context;
        //    _roleManager = roleManager;
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _emailService = emailService;
        //    _webHostEnvironment = webHostEnvironment;
        //}

        //public async Task<IActionResult> Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    User appUser = new User
        //    {
        //        Email = dto.Email,
        //        FullName = dto.FullName,
        //        UserName = dto.Username,
        //    };

        //    IdentityResult result = await _userManager.CreateAsync(appUser, dto.Password);

        //    if (!result.Succeeded)
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        }
        //        return View();
        //    }

        //    await _userManager.AddToRoleAsync(appUser, "User");


        //    string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
        //    var url = $"{Request.Scheme}://{Request.Host}{Url.Action("VerifyEmail", "Identity", new { email = appUser.Email, token = token })}";

        //    string path = Path.Combine(_webHostEnvironment.WebRootPath, "Templates", "Verify.html");

        //    string body = string.Empty;

        //    body = System.IO.File.ReadAllText(path);

        //    body = body.Replace("{{url}}", url);


        //    await _emailService.SendEmail(appUser.Email, "Verify Email", body);
        //    TempData["emailverify"] = "verify";
        //    return RedirectToAction("index", "Home");
        //}


        ////public async Task<IActionResult> VerifyEmail(string email, string token)
        ////{
        ////    User appUser = await _userManager.FindByEmailAsync(email);
        ////    var res = await _userManager.ConfirmEmailAsync(appUser, token);
        ////    return RedirectToAction(nameof(Login));
        ////}

        //public async Task<IActionResult> VerifyEmail(string email, string token)
        //{
        //    User appUser = await _userManager.FindByEmailAsync(email);

        //    if (appUser == null)
        //    {
        //        // Handle the case where the user is not found
        //        return NotFound();
        //    }

        //    var result = await _userManager.ConfirmEmailAsync(appUser, token);

        //    if (result.Succeeded)
        //    {
        //        TempData["EmailVerified"] = "Your email has been successfully verified. You can now log in.";
        //    }
        //    else
        //    {
        //        // Handle the case where email confirmation fails
        //        TempData["EmailVerificationFailed"] = "Email verification failed. Please try again.";
        //    }

        //    return RedirectToAction(nameof(Login));
        //}









        //    return RedirectToAction("Index", "Home");
        //}


        ////public async Task<IActionResult> CreateRole()
        ////{
        ////    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        ////    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        ////    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        ////    return Json("ok");
        ////}

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("index", "home");
        //}
        //[Authorize]
        //public async Task<IActionResult> Update()
        //{
        //    var query = _userManager.Users.Where(x => x.UserName == User.Identity.Name);
        //    UpdateDto? updateDto = await query.Select(x => new UpdateDto { UserName = x.UserName, FullName = x.FullName })
        //        .FirstOrDefaultAsync();

        //    return View(updateDto);
        //}

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Update(UpdateDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    User appUser = await _userManager.FindByNameAsync(User.Identity.Name);

        //    appUser.FullName = dto.FullName;
        //    appUser.UserName = dto.UserName;
        //    IdentityResult result = await _userManager.UpdateAsync(appUser);

        //    if (!result.Succeeded)
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        }
        //        return View();
        //    }

        //    if (!string.IsNullOrWhiteSpace(dto.OldPassword))
        //    {
        //        var res = await _userManager.ChangePasswordAsync(appUser, dto.OldPassword, dto.NewPassword);

        //        if (!res.Succeeded)
        //        {
        //            foreach (var item in res.Errors)
        //            {
        //                ModelState.AddModelError("", item.Description);
        //            }
        //            return View();
        //        }
        //    }
        //    await _signInManager.SignInAsync(appUser, true);
        //    return RedirectToAction(nameof(Update));
        //}


        //public async Task<IActionResult> ForgotPassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> ForgotPassword(string email)
        //{
        //    User appUser = await _userManager.FindByEmailAsync(email);


        //    if (appUser == null)
        //    {
        //        ModelState.AddModelError("", "please add valid email");
        //        return View();
        //    }


        //    string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
        //    var url = $"{Request.Scheme}://{Request.Host}{Url.Action("ResetPassword", "Identity", new { email = appUser.Email, token = token })}";

        //    string path = Path.Combine(_webHostEnvironment.WebRootPath, "Templates", "Verify.html");

        //    string body = string.Empty;

        //    body = System.IO.File.ReadAllText(path);

        //    body = body.Replace("{{url}}", url);


        //    await _emailService.SendEmail(appUser.Email, "Reset Passsword", body);
        //    TempData["resetPassword"] = "reset";
        //    return RedirectToAction("index", "home");
        //}


        //public async Task<IActionResult> ResetPassword(string email, string token)
        //{
        //    User appUser = await _userManager.FindByEmailAsync(email);

        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(new ResetPasswordDto { Email = email, Token = token });
        //}

        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        //{
        //    User appUser = await _userManager.FindByEmailAsync(dto.Email);

        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    var res = await _userManager.ResetPasswordAsync(appUser, dto.Token, dto.Password);

        //    if (!res.Succeeded)
        //    {
        //        foreach (var item in res.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        }
        //        return View(dto);
        //    }
        //    return View(nameof(Login));
        //}




        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User user = new User { Email = "admin@edu.az", FullName = "Nicat Azizov", UserName = "Admin" };
        //    IdentityResult res = await _userManager.CreateAsync(user, "Admin123@");

        //    if (!res.Succeeded)
        //    {
        //        return Json(res.Errors);
        //    }

        //    await _userManager.AddToRoleAsync(user, "SuperAdmin");
        //    return Json("ok");
        //}






        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid) return View();
            var user = new User
            {
                Email = model.Email,
                UserName = model.Username,
                FullName=model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, "User");

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            string link = Url.Action("ConfrimUser", "Account", new { email = model.Email, token }, HttpContext.Request.Scheme, HttpContext.Request.Host.ToString());

            MailMessage message = new MailMessage("Nijataziz09@gmail.com", user.Email)
            {
                Subject = "Confrimation email",
                Body = $"<a href = \"{link}\"> Click to confrim email.</a>",
                IsBodyHtml = true
            };

            SmtpClient smtpClient = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("7l25x5f@code.edu.az", "tevtqiirkcyyiglb")
            };

            smtpClient.Send(message);

               return RedirectToAction("index", "Home");
        }


        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser =await _userManager.FindByNameAsync(dto.UserNameOrEmail);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Username or email or password incorrect");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult res = await _signInManager.PasswordSignInAsync(appUser, dto.Password, dto.RememberMe, true);
            if (!res.Succeeded)
            {
                if (res.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your Account was blocked for 1 minutes");
                    return View();
                }

                if (res.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Verify your email");
                    return View();
                }

                ModelState.AddModelError("", "Username or email or password incorrect");
                return View();
            }




            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ForgotPassword(AccountForgotPasswordVM forgotPassword)
        //{
        //    if (!ModelState.IsValid) return NotFound();

        //    User exsistUser = await _userManager.FindByEmailAsync(forgotPassword.Email);

        //    if (exsistUser is null)
        //    {
        //        ModelState.AddModelError("Email", "Email isn't found");
        //        return View();
        //    }
        //    string body = string.Empty;
        //    string subject = "Verify Password Reset";



        //    string token = await _userManager.GeneratePasswordResetTokenAsync(exsistUser);
        //    string link = Url.Action(nameof(ResetPassword), "Account", new { userId = exsistUser.Id, token = token }, HttpContext.Request.Scheme);

        //    body = $"<a href={link}>Reset Password</a>";

        //    body = body.Replace("{{fullname}}", exsistUser.Name);
        //    //await _emailService.Send(new AccountMailRequestVM { ToEmail = forgotPassword.Email, Subject = "ResetPassword", Body = $"<a href=\"{link}\">Reset Password</a>" });
        //    _emailService.Send(exsistUser.Email, subject, body);

        //    ModelState.AddModelError("Email", "Emailinizi yoxlayın!");

        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> ResetPassword(string userId, string token)
        //{
        //    if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) return BadRequest();

        //    User user = await _userManager.FindByIdAsync(userId);

        //    if (user is null) return NotFound();

        //    return View(new AccountResetPasswordVM { Token = token, UserId = userId });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ResetPassword(AccountResetPasswordVM resetPassword, string userId, string token)
        //{
        //    if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
        //        return BadRequest();

        //    if (!ModelState.IsValid)
        //        return View(resetPassword);

        //    User user = await _userManager.FindByIdAsync(userId);
        //    if (user is null)
        //        return NotFound();

        //    var result = await _userManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //        return View(resetPassword);
        //    }

        //    return RedirectToAction(nameof(Login));
        //}

        public async Task<IActionResult> ConfrimUser(string email, string token)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(x=>x.Email==email);

            if (user == null) return NotFound();

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Incorrect confrim");
                return RedirectToAction("Index", "Home");
            }

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
    }
}
