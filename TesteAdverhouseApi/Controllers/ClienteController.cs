using Microsoft.AspNetCore.Mvc;
using TesteAdverhouseApi.Infrastructure;
using TesteAdverhouseApi.Model;

namespace TesteAdverhouseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        [HttpGet(Name = "GetClienteAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClienteModel>))]
        public async Task<IActionResult> GetBuyersAsync()
        {
            try
            {
                ClienteRepository dal = new ClienteRepository();
                var ret = await dal.GetAllAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controller Cliente, rota GetCliente " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClienteModel>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ClienteRepository dal = new ClienteRepository();
                var ret = await dal.GetByIdAsync(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controller Cliente, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        [HttpPost(Name = "InsertCliente")]
        public async Task Post(ClienteModel clienteModel)
        {
            try
            {
                ClienteRepository dal = new ClienteRepository();
                await dal.InsertAsync(clienteModel);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controller Cliente, rota Post " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpPut(Name = "UpdateCliente")]
        public async Task Update(ClienteModel buyerModel)
        {
            try
            {
                ClienteRepository dal = new ClienteRepository();
                await dal.UpdateAsync(buyerModel);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controller Cliente, rota Put " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            try
            {
                ClienteRepository dal = new ClienteRepository();
                await dal.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Buyer, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }
    }
}
