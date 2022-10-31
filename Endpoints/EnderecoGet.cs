using Microsoft.AspNetCore.Mvc;
using ViaCepApi.Entities;
using ViaCepApi.Services;

namespace ViaCepApi.Endpoints
{
    public class EnderecoGet
    {

        public static string Template => "api/v1/cep/{cep}";

        public static string[] Metodo => new string[] { HttpMethod.Get.ToString() };

        public static Delegate Func => Acao;

        public static IResult Acao([FromRoute] string cep)
        {
            if (cep.Length != 8)
            {
                return Results.BadRequest(new { menssagem = "A quantidade de numero do cep não pode ser diferente de 8 digitos" });
            }


            Task<Endereco> enderecoTask = EnderecoService.Integracao(cep);
            Endereco endereco = enderecoTask.Result;

            if (endereco.cep == null)
            {

                return Results.NotFound(new { menssagem = "Cep não encontrado" });
            }

            return Results.Ok(endereco);
        }
    }
}
