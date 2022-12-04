using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RpgMvc.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RpgMvc.Controllers
{
    public class UsuariosController : Controller
    {
        public string uriBase = "http://giospo.somee.com/RpgApi/Usuarios/";
        //xyz tem que ser substituído pelo endereço da sua API.

        [HttpGet]
        public ActionResult Index()
        {
            return View("CadastrarUsuario");
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] =
                        string.Format("Usuário {0} Registrado com sucesso! Faça o login para acessar.", u.Username);
                    return View("AutenticarUsuario");
                }
                else
                {
                    throw new System.Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult IndexLogin()
        {
            return View("AutenticarUsuario");
        }

        /*
        [HttpPost]
        public async Task<ActionResult> RegistrarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("aplication/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] =
                        string.Format("Usuário {0} Registrado com sucesso! Faça o login para acessar.", u.Username);
                    return View("AutenticarUsuario");
                }
                else
                {
                    throw new System.Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return IndexLogin("Index");
            }
        }
        */

        [HttpPost]
        public async Task<ActionResult> AutenticarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Autenticar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("SessionTokenUsuario", serialized);
                    HttpContext.Session.SetString("SessionUsername", u.Username);
                    TempData["Mensagem"] = string.Format("Bem-vindo {0}!!!", u.Username);
                    return RedirectToAction("Index", "Personagens");
                }
                else
                {
                    throw new System.Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return IndexLogin();
            }
        }

        [HttpGet]
        public async Task<ActionResult> IndexInformacoesAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                //Novo: Recuperação informação da sessão
                string login = HttpContext.Session.GetString("SessionUsername");
                string uriComplementar =
                $"GetByLogin/{login}";
                HttpResponseMessage response = await httpClient.GetAsync(uriBase +
                uriComplementar);
                string serialized = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    UsuarioViewModel p = await Task.Run(() =>
                    JsonConvert.DeserializeObject<UsuarioViewModel>(serialized));
                    return View(p);
                }
                else
                {
                    throw new System.Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AlterarEmail(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string uriComplementar = "AtualizarEmail";
                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await httpClient.PutAsync(uriBase + uriComplementar, content);
                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = ("E-mail alterado com sucesso.");
                }
                else
                {
                    throw new System.Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
            }
            return RedirectToAction("IndexInformacoes");
        }

        [HttpGet]
        public async Task<ActionResult> ObterDadosAlteracaoSenha()
        {
            UsuarioViewModel viewModel = new UsuarioViewModel();
            try
            {
                HttpClient httpClient = new HttpClient();
                string login = HttpContext.Session.GetString("SessionUsername");
                string uriComplementar = $"GetByLogin/{login}";
                HttpResponseMessage response = await httpClient.GetAsync(uriBase +
                uriComplementar);
                string serialized = await response.Content.ReadAsStringAsync();
                TempData["TituloModalExterno"] = "Alteração de Senha";
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    viewModel = await Task.Run(() =>
                    JsonConvert.DeserializeObject<UsuarioViewModel>(serialized));
                    return PartialView("_AlteracaoSenha", viewModel);
                }
                else
                    throw new System.Exception(serialized);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("IndexInformacoes");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AlterarSenha(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", token);
                string uriComplementar = "AlterarSenha";
                u.Username = HttpContext.Session.GetString("SessionUsername");
                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PutAsync(uriBase +
                uriComplementar, content);
                string serialized = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string mensagem = "Senha alterada com sucesso.";
                    TempData["Mensagem"] = mensagem; //Mensagem guardada do TempData que                    aparcerá na página pai do modal
                return Json(mensagem); //Mensagem que será exibida no alert da Função que                    chamou este método
                }
                else
                    throw new System.Exception(serialized);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
