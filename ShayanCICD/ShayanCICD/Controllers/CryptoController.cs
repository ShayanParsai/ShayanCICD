using Microsoft.AspNetCore.Mvc;

namespace ShayanCICD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private const int Shift = 3; // Caesar cipher shift

        [HttpGet("encrypt")]
        public IActionResult Encrypt([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Text cannot be empty.");

            string encryptedText = new string(text.Select(c => (char)(c + Shift)).ToArray());

            // Logga krypteringen i konsolen
            Console.WriteLine($"[LOG] Encrypted '{text}' to '{encryptedText}'");

            return Ok(new { Original = text, Encrypted = encryptedText });
        }


        [HttpGet("decrypt")]
        public IActionResult Decrypt([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Text cannot be empty.");

            string decryptedText = new string(text.Select(c => (char)(c - Shift)).ToArray());
            return Ok(new { Encrypted = text, Decrypted = decryptedText });
        }
    }
}

