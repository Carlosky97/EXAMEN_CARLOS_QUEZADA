using ApiConsumoTaller.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ApiConsumoTaller
{
    public class APIGateway
    {
        // URL de la API con la que se va a interactuar
        private string url = "https://localhost:7107/api/Mecanico";

        // Instancia de HttpClient para realizar las solicitudes HTTP a la API
        private HttpClient httpClient = new HttpClient();

        // Método para obtener la lista de mecánicos desde la API
        public List<Mecanico> ListMecanicos()
        {
            // Lista que almacenará los mecánicos recuperados de la API
            List<Mecanico> mecanicos = new List<Mecanico>();

            // Configuración de seguridad si la URL utiliza HTTPS
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                // Realiza una solicitud GET a la API
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                // Verifica si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Lee y deserializa el contenido de la respuesta en una lista de mecánicos
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Mecanico>>(result);

                    // Asigna la lista de mecánicos si la deserialización fue exitosa
                    if (datacol != null)
                    {
                        mecanicos = datacol;
                    }
                }
                else
                {
                    // Si la solicitud no fue exitosa, lanza una excepción con el mensaje de error
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + result);
                }
            }
            catch (Exception ex)
            {
                // Captura y relanza la excepción con un mensaje de error
                throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + ex.Message);
            }
            finally { /* Código opcional a ejecutar después del bloque try-catch */ }

            // Devuelve la lista de mecánicos obtenida de la API
            return mecanicos;
        }

        // Método para crear un nuevo mecánico a través de la API
        public Mecanico CreateMecanico(Mecanico mecanico)
        {
            // Configuración de seguridad si la URL utiliza HTTPS
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Serializa el objeto Mecanico a formato JSON
            string json = JsonConvert.SerializeObject(mecanico);

            try
            {
                // Realiza una solicitud POST a la API con el JSON del nuevo mecánico
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                // Verifica si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Lee y deserializa el contenido de la respuesta en un objeto Mecanico
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Mecanico>(result);

                    // Asigna el objeto Mecanico creado si la deserialización fue exitosa
                    if (data != null)
                        mecanico = data;
                }
                else
                {
                    // Si la solicitud no fue exitosa, lanza una excepción con el mensaje de error
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + result);
                }
            }
            catch (Exception ex)
            {
                // Captura y relanza la excepción con un mensaje de error
                throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + ex.Message);
            }
            finally { /* Código opcional a ejecutar después del bloque try-catch */ }

            // Devuelve el objeto Mecanico creado a través de la API
            return mecanico;
        }

        // Método para obtener un mecánico por su ID desde la API
        public Mecanico GetMecanico(int id)
        {
            // Objeto Mecanico que almacenará el mecánico recuperado de la API
            Mecanico mecanico = new Mecanico();

            // Modifica la URL para incluir el ID del mecánico solicitado
            url = url + "/" + id;

            // Configuración de seguridad si la URL utiliza HTTPS
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                // Realiza una solicitud GET a la API
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                // Verifica si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Lee y deserializa el contenido de la respuesta en un objeto Mecanico
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Mecanico>(result);

                    // Asigna el objeto Mecanico si la deserialización fue exitosa
                    if (data != null)
                        mecanico = data;
                }
                else
                {
                    // Si la solicitud no fue exitosa, lanza una excepción con el mensaje de error
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + result);
                }
            }
            catch (Exception ex)
            {
                // Captura y relanza la excepción con un mensaje de error
                throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + ex.Message);
            }
            finally { /* Código opcional a ejecutar después del bloque try-catch */ }

            // Devuelve el objeto Mecanico obtenido de la API
            return mecanico;
        }

        // Método para actualizar un mecánico a través de la API
        public void UpdateMecanico(Mecanico mecanico)
        {
            // Configuración de seguridad si la URL utiliza HTTPS
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Obtiene el ID del mecánico para incluirlo en la URL
            int id = mecanico.idMecanico;

            // Modifica la URL para incluir el ID del mecánico que se actualizará
            url = url + "/" + id;

            // Serializa el objeto Mecanico a formato JSON
            string Json = JsonConvert.SerializeObject(mecanico);

            try
            {
                // Realiza una solicitud PUT a la API con el JSON actualizado del mecánico
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(Json, Encoding.UTF8, "application/json")).Result;

                // Verifica si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Lee y almacena el contenido de la respuesta (no se utiliza en este caso)
                    string result = response.Content.ReadAsStringAsync().Result;

                    // Se podría implementar lógica adicional si es necesario
                }
                else
                {
                    // Si la solicitud no fue exitosa, lanza una excepción con el mensaje de error
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + result);
                }
            }
            catch (Exception)
            {
                // Captura y maneja la excepción si ocurre algún error en el bloque try
                // Podría implementarse lógica adicional si es necesario
            }
            finally { /* Código opcional a ejecutar después del bloque try-catch */ }

            // El método no devuelve ningún valor, ya que la actualización se realiza de manera asíncrona
            return;
        }

        // Método para eliminar un mecánico por su ID a través de la API
        public void DeleteMecanico(int id)
        {
            // Configuración de seguridad si la URL utiliza HTTPS
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Modifica la URL para incluir el ID del mecánico que se eliminará
            url = url + "/" + id;

            try
            {
                // Realiza una solicitud DELETE a la API
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                // Verifica si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Lee y almacena el contenido de la respuesta (no se utiliza en este caso)
                    string result = response.Content.ReadAsStringAsync().Result;

                    // Se podría implementar lógica adicional si es necesario
                }
                else
                {
                    // Si la solicitud no fue exitosa, lanza una excepción con el mensaje de error
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API. Información de error: " + result);
                }
            }
            catch (Exception)
            {
                // Captura y maneja la excepción si ocurre algún error en el bloque try
                // Podría implementarse lógica adicional si es necesario
            }
            finally { /* Código opcional a ejecutar después del bloque try-catch */ }

            // El método no devuelve ningún valor, ya que la eliminación se realiza de manera asíncrona
            return;
        }
    }
}
