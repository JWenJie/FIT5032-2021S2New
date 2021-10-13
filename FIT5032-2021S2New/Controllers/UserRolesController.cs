using FIT5032_2021S2New.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_2021S2New.Controllers
{
    public class UserRolesController : Controller
    {

        private ApplicationDbContext context = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager;

        public UserRolesController()
        {
            var userStore = new UserStore<ApplicationUser>(context);
            userManager = new UserManager<ApplicationUser>(userStore);
        }

        // GET: UserRoles
        public ActionResult Index()
        {
            var roles = this.context.Roles.ToList();
            return View(roles);
        }

        //Get: Create Roles
        public ActionResult CreateRole()
        {
            return View();
        }

        //Post: Create Roles
        [HttpPost]
        public ActionResult CreateRole(FormCollection formCollection)
        {
            try
            {
                var newRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = formCollection["Role Name"]
                };
                context.Roles.Add(newRole);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string roleName)
        {
            var role = context.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            context.Roles.Remove(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditRole(string roleName)
        {
            var role = context.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            return View(role);
        }

        [HttpPost]
        public ActionResult EditRole(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(role);
            }
        }

        //GET: AddUserRole
        public ActionResult AddRoleToUser()
        {
            var rolesList = context.Roles.ToList().Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            var usersList = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            ViewBag.Users = usersList;
            ViewBag.Roles = rolesList;
            return View();
        }

        [HttpPost]
        public ActionResult AddRoleToUser(string Email, string Role)
        {
            try
            {
                var user = userManager.FindByEmail(Email);
                userManager.AddToRole(user.Id, Role);
                ViewBag.Roles = context.Roles.ToList().Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
                ViewBag.Users = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            } 
            catch (Exception e)
            {
                ViewBag.Errormessage = e.Message;
            }
            return View();
        }

        //List User Roles
        public ActionResult ListUserRoles()
        {
            ViewBag.Users = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ListUserRoles(string Email)
        {
            try
            {
                var user = userManager.FindByEmail(Email);
                ViewBag.Roles = userManager.GetRoles(user.Id);
                ViewBag.Users = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
                ViewBag.Email = Email;
            }
            catch (Exception e)
            {
                ViewBag.Errormessage = e.Message;
            }
            return View();
        }

        public ActionResult DeleteUsersRole(string Email, string Role)
        {
            var user = userManager.FindByEmail(Email);
            if(this.userManager.IsInRole(user.Id, Role))
            {
                this.userManager.RemoveFromRole(user.Id, Role);
            }
            return RedirectToAction("Index");
        }
    }
}