using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MockQueryable;
using Moq;
using NUnit.Framework;
using System.Security.Claims;
using TableTree.Data.Models;
using AccountServiceOperations = TableTree.Services.Data.AccountService;

namespace TableTree.Services.Data.Testting
{
    public class AccountService
    {
        List<ApplicationUser> users = null;

        [SetUp]
        public void Setup()
        {
            users = new List<ApplicationUser>()
            {
                new()
                {
                    Id = Guid.Parse("570cc7c9-9dc7-44a3-8246-795f931aff77"),
                    Email = "test1@gmail.com",
                    UserName = "test1@gmail.com",
                },
                new()
                {
                    Id = Guid.Parse("6d457a9e-cb6c-470f-8922-169f0806dad4"),
                    Email = "test2@gmail.com",
                    UserName = "test2@gmail.com",
                },
                new()
                {
                    Id = Guid.Parse("0afdc890-2ce0-48e8-9b01-0084990df613"),
                    Email = "test3@gmail.com",
                    UserName = "test3@gmail.com",
                },
            };
        }

        [Test]
        public async Task AccountServiceReturns_GetAllUsers()
        {
            var mockedUsers = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            mockedUsers.Setup(m => m.Users)
                .Returns(users.AsQueryable().BuildMock());

            var service = new AccountServiceOperations(mockedUsers.Object, null);

            var result = await service.GetlAllUsers();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.First().Id, Is.EqualTo("570cc7c9-9dc7-44a3-8246-795f931aff77"));
        }

        [Test]
        public async Task AccountServiceReturns_MakeUserAdmin()
        {
            var mockedUsers = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            mockedUsers.Setup(m => m.Users)
                .Returns(users.AsQueryable().BuildMock());

            var user = mockedUsers.Object.Users.Where(u => u.Id == Guid.Parse("570cc7c9-9dc7-44a3-8246-795f931aff77")).First();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuth"));

            Mock<SignInManager<ApplicationUser>> mockSignInManager = new Mock<SignInManager<ApplicationUser>>(
                mockedUsers.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object,
                new Mock<IUserConfirmation<ApplicationUser>>().Object
            );

            var mockRoleManager = new Mock<RoleManager<ApplicationRole>>(
                Mock.Of<IRoleStore<ApplicationRole>>(),
                Array.Empty<IRoleValidator<ApplicationRole>>(),
                Mock.Of<ILookupNormalizer>(),
                Mock.Of<IdentityErrorDescriber>(),
                Mock.Of<ILogger<RoleManager<ApplicationRole>>>());

            mockSignInManager.Setup(sm => sm.CreateUserPrincipalAsync(user))
                .ReturnsAsync(claimsPrincipal);

            var service = new AccountServiceOperations(mockedUsers.Object, mockRoleManager.Object);

            var claimsPrincipalUser = await mockSignInManager.Object.CreateUserPrincipalAsync(user);

            mockedUsers.Setup(m => m.FindByNameAsync(claimsPrincipalUser.Identity.Name))
                .ReturnsAsync(user);

            await service.MakeUserAdmin(claimsPrincipalUser);

            mockedUsers.Verify(
                m => m.AddToRoleAsync(
                    It.Is<ApplicationUser>(u => u.Id == user.Id && u.UserName == user.UserName),
                    It.Is<string>(r => r == "Admin")),
                Times.Once);

            mockSignInManager.Verify(
                sm => sm.CreateUserPrincipalAsync(It.IsAny<ApplicationUser>()),
                Times.Once);

            mockedUsers.Verify(
                m => m.Users,
                Times.AtLeastOnce);
        }


        [Test]
        public async Task AccountServiceReturns_MakeUserGlobalAdmin()
        {
            var mockedUsers = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            mockedUsers.Setup(m => m.Users)
                .Returns(users.AsQueryable().BuildMock());

            var user = mockedUsers.Object.Users.Where(u => u.Id == Guid.Parse("570cc7c9-9dc7-44a3-8246-795f931aff77")).First();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuth"));

            Mock<SignInManager<ApplicationUser>> mockSignInManager = new Mock<SignInManager<ApplicationUser>>(
                mockedUsers.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object,
                new Mock<IUserConfirmation<ApplicationUser>>().Object
            );

            var mockRoleManager = new Mock<RoleManager<ApplicationRole>>(
                Mock.Of<IRoleStore<ApplicationRole>>(),
                Array.Empty<IRoleValidator<ApplicationRole>>(),
                Mock.Of<ILookupNormalizer>(),
                Mock.Of<IdentityErrorDescriber>(),
                Mock.Of<ILogger<RoleManager<ApplicationRole>>>());

            mockSignInManager.Setup(sm => sm.CreateUserPrincipalAsync(user))
                .ReturnsAsync(claimsPrincipal);

            var service = new AccountServiceOperations(mockedUsers.Object, mockRoleManager.Object);

            var claimsPrincipalUser = await mockSignInManager.Object.CreateUserPrincipalAsync(user);

            mockedUsers.Setup(m => m.FindByNameAsync(claimsPrincipalUser.Identity.Name))
                .ReturnsAsync(user);

            await service.MakeUserGlobalAdmin(claimsPrincipalUser);

            mockedUsers.Verify(
                m => m.AddToRoleAsync(
                    It.Is<ApplicationUser>(u => u.Id == user.Id && u.UserName == user.UserName),
                    It.Is<string>(r => r == "GlobalAdmin")),
                Times.Once);

            mockSignInManager.Verify(
                sm => sm.CreateUserPrincipalAsync(It.IsAny<ApplicationUser>()),
                Times.Once);

            mockedUsers.Verify(
                m => m.Users,
                Times.AtLeastOnce);
        }

        [Test]
        public async Task AccountServiceReturns_DeleteUser()
        {
            var mockedUsers = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            mockedUsers.Setup(m => m.Users)
                .Returns(users.AsQueryable().BuildMock());

            var user = mockedUsers.Object.Users.Where(u => u.Id == Guid.Parse("570cc7c9-9dc7-44a3-8246-795f931aff77")).First();

            mockedUsers.Setup(m => m.FindByIdAsync(Guid.Parse("570cc7c9-9dc7-44a3-8246-795f931aff77").ToString()))
                .ReturnsAsync(user);

            mockedUsers.Setup(m => m.DeleteAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(IdentityResult.Success);

            var service = new AccountServiceOperations(mockedUsers.Object, null);

            var result = await service.DeleteUser("570cc7c9-9dc7-44a3-8246-795f931aff77");

            Assert.That(result, Is.EqualTo(true));
            mockedUsers.Verify(m => m.DeleteAsync(It.Is<ApplicationUser>(u => u.Id == user.Id)), Times.Once);
        }
    }
}
