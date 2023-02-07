using UsersClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UsersClient.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                ConfigureClient(client);
                var response = await client.GetAsync("users");

                if (response.IsSuccessStatusCode)
                {
                    return View(await response.Content.ReadAsAsync<IEnumerable<UserView>>());
                }
                return View();
            }
        }

        public ActionResult New()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserView UserView)
        {
            using (var client = new HttpClient())
            {
                ConfigureClient(client);
                var stringContent = new StringContent(JsonConvert.SerializeObject(UserView), Encoding.UTF8, "application/json");


                HttpResponseMessage response = null;
                if (UserView.id == 0)
                    response = await client.PostAsync("users", stringContent);
                else
                    response = await client.PutAsync("users", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }

        }

        public async Task<ActionResult> Edit(int id)
        {
            UserView UserViewModel = null;
            using (var client = new HttpClient())
            {
                ConfigureClient(client);
                var stringContent = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                var response = await client.GetAsync("users/" + id);

                if (response.IsSuccessStatusCode)
                {
                    UserViewModel = await response.Content.ReadAsAsync<UserView>();
                }

                return View(UserViewModel);
            }

        }

        public async Task<ActionResult> Delete(int id)
        {
            UserView UserViewModel = null;
            using (var client = new HttpClient())
            {
                ConfigureClient(client);
                var stringContent = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                var response = await client.GetAsync("users/" + id);

                if (response.IsSuccessStatusCode)
                {
                    UserViewModel = await response.Content.ReadAsAsync<UserView>();
                }

                return View(UserViewModel);
            }

        }

        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserView UserViewModel = null;
            using (var client = new HttpClient())
            {
                ConfigureClient(client);
                var stringContent = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                var response = await client.DeleteAsync("users/" + id);

                if (response.IsSuccessStatusCode)
                {
                    UserViewModel = await response.Content.ReadAsAsync<UserView>();
                }
                else
                {
                    return View(UserViewModel);
                }

                return RedirectToAction("Index");
            }

        }

        private static void ConfigureClient(HttpClient client)
        {
            string uri = ConfigurationManager.AppSettings["servicesUrl"].ToString();
            client.BaseAddress = new Uri("http://localhost:61576/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

}