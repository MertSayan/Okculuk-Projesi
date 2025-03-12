using Application.Interfaces.GoogleFormInterface;
using Domain;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;



namespace Persistence.Repositories.GoogleFormRepositories
{
    public class GoogleFormRepository : IGoogleFormRepository
    {
        private readonly OkculukContext _context;

        public GoogleFormRepository(OkculukContext context)
        {
            _context = context;
        }

        public async Task<List<GoogleForm>> GetAllGoogleForm()
        {
            return await _context.GoogleForms.ToListAsync();
        }

        public async Task CreateGoogleForm(string id)
        {
            string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
            string ApplicationName = "Google Sheets API Test";
            string SpreadsheetId = $"{id}"; // Buraya kendi Google Sheets ID'ni yaz
            string Range = "A2:F"; // Bütün verileri al

            GoogleCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var request = service.Spreadsheets.Values.Get(SpreadsheetId, Range);
            ValueRange response = await request.ExecuteAsync();
            IList<IList<object>> values = response.Values;

            if (values == null || values.Count == 0)
            {
                Console.WriteLine("Google Sheets'ten veri alınamadı.");
                return;
            }

            List<GoogleForm> yanitlar = new List<GoogleForm>();

            foreach (var row in values)
            {
                try
                {
                    GoogleForm yanit = new GoogleForm
                    {
                        CreatedDate = DateTime.Parse(row[0].ToString()),
                        EventId = Convert.ToInt32(row[1]),
                        Name = row[2].ToString(),
                        Surname = row[3].ToString(),
                        IsJoin = row[4].ToString().Trim(),
                        RejectedReason = row[5].ToString()
                    };

                    yanitlar.Add(yanit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                }
            }

            await _context.GoogleForms.AddRangeAsync(yanitlar);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteDataTable()
        {
            await _context.GoogleForms.ExecuteDeleteAsync();
        }
    }
}
