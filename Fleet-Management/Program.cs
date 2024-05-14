using Fleet_Managment;
using Fleet_Managment.Context;

var builder = WebApplication.CreateBuilder(args);
// Configurar la conexión a la base de datos utilizando ConnectionBD
builder.Services.AddSingleton<Connection>();
// Configurar el servicio de base de datos utilizando AppDbContext
builder.Services.AddDbContext<ContextDB>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



//using Npgsql;
//using System;
//var builder = WebApplication.CreateBuilder(args);
//// Add services to the container.
//builder.Services.AddControllers();
////Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//var app = builder.Build();
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();
//namespace Fleet_Managment
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ConnectionBD connection = new ConnectionBD();
//            try
//            {
//                string query = "SELECT * FROM taxis ORDER BY id";
//                using (NpgsqlCommand cmdAction = new NpgsqlCommand(query, connection.Open_Connection()))
//                {
//                    using (NpgsqlDataReader reader = cmdAction.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            Console.WriteLine("Id Taxi: " + reader["id"].ToString() + ", Placa: " + reader["plate"].ToString());
//                        }
//                    }
//                }
//            }
//            finally
//            {
//                connection.Close_Connetion();
//            }
//        }
//    }
//}