using System.Globalization;

namespace MyRecipeApp.API.Middleware
{
    public class CultureMiddleware
    {
        private RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en");                // Configura o CultureInfo padrão para ingles

            if (!string.IsNullOrEmpty(requestedCulture) && supportedLanguages.Any(c => c.Name.Equals(requestedCulture)))        // Caso o usuário informe outro valor VÁLIDO de lingua, sobrescreve o valor para essa lingua
            {
                cultureInfo = new CultureInfo(requestedCulture);        
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;


            await _next(context);                                           // Permite que o fluxo continue e siga para o proximo Middleware ou para a API
        }
    }
}
