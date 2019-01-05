
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeGenNHibernate.CP.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                // USUARIOS
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                usuarioCEN.Registrarse ("danibravo@gmail.com", "123456789", "Daniel", "Bravo Garcia", "ElDani", new DateTime (1995, 11, 01), "Alicante", "Alicante", "Nuevo Usuario", "981239123");
                usuarioCEN.Registrarse ("hectorsteve@gmail.com", "2143658709", "Hector", "Steve Yague", "ElHector", new DateTime (1999, 04, 21), "Alicante", "Elche", "Nuevo Usuario", "76123123");
                usuarioCEN.Registrarse ("sergito19@hotmail.com", "123sube321", "Sergio", "Sebastian Aracil", "ElSergio", new DateTime (1998, 01, 19), "Alicante", "Alicante", "Nuevo Usuario", "7812631");
                usuarioCEN.Registrarse ("imrubensi@gmail.com", "password", "Ruben", "Rubio Martinez", "RUBENSI", new DateTime (1997, 08, 16), "Alicante", "San Isidro", "Nuevo Usuario", "871263123");
                usuarioCEN.Registrarse ("4321@gmail.com", "4321", "4321", "1234 4321", "4321", new DateTime (1997, 08, 16), "Alicante", "San Isidro", "Nuevo Usuario", "871263123");
                usuarioCEN.Registrarse ("marianorajoy@outlook.es", "arribaespanya", "Mariano", "Rajoy Brey", "Rajoy", new DateTime (1955, 03, 27), "Madrid", "Madrid", "Nuevo Usuario", "971622133");

                // ADMINISTRADORES
                AdministradorCEN administradorCEN = new AdministradorCEN ();
                administradorCEN.New_ ("alexgladiator@petme.com", "Alejandro", "Castro Valero", "Alex", new DateTime (1997, 01, 29), "Alicante", "Albatera", 500f, "76125371", PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum.activo, "ttttttttty", "Penalizar comentarios obscenos");
                administradorCEN.New_ ("1234@petme.com", "1234", "Castro Valero", "1234", new DateTime (1997, 01, 29), "Alicante", "Albatera", 500f, "76125371", PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum.activo, "ttttttttty", "Penalizar comentarios obscenos");

                // INCREMENTAMOS SUS CARTERAS
                usuarioCEN.IncrementarCartera ("danibravo@gmail.com", 100);
                usuarioCEN.IncrementarCartera ("hectorsteve@gmail.com", 100);
                usuarioCEN.IncrementarCartera ("sergito19@hotmail.com", 100);
                usuarioCEN.IncrementarCartera ("sergito19@hotmail.com", 100);
                usuarioCEN.IncrementarCartera ("imrubensi@gmail.com", 100);
                usuarioCEN.IncrementarCartera ("marianorajoy@outlook.es", 100);
                usuarioCEN.IncrementarCartera ("alexgladiator@petme.com", 100);

                // CREAMOS Y PUBLICAMOS ANUNCIOS
                IList<string> animales1 = new List<string>();
                animales1.Add ("perro"); animales1.Add ("gato"); animales1.Add ("foca");
                IList<double> tarifas1 = new List<double>();
                tarifas1.Add (77.5); tarifas1.Add (45.01); tarifas1.Add (101.9);
                IList<string> animales2 = new List<string>();
                animales2.Add ("perro"); animales2.Add ("gato");
                IList<double> tarifas2 = new List<double>();
                tarifas2.Add (60); tarifas2.Add (33.336);
                IList<string> animales3 = new List<string>();
                animales3.Add ("loro"); animales3.Add ("periquito");
                IList<double> tarifas3 = new List<double>();
                tarifas3.Add (15.6); tarifas3.Add (10);
                IList<string> animales4 = new List<string>();
                animales4.Add ("lagarto");
                IList<double> tarifas4 = new List<double>();
                tarifas4.Add (55.2);
                IList<string> animales5 = new List<string>();
                animales5.Add ("hurón"); animales5.Add ("perro");
                IList<double> tarifas5 = new List<double>();
                tarifas5.Add (25.5); tarifas5.Add (16);
                IList<string> animales6 = new List<string>();
                animales6.Add ("halcón");
                IList<double> tarifas6 = new List<double>();
                tarifas6.Add (15.9);

                UsuarioCP usuarioCP = new UsuarioCP ();
                usuarioCP.CrearAnuncio ("hectorsteve@gmail.com", new DateTime (2018, 04, 14), new DateTime (2018, 06, 21), "Avenida Indalecio Prieto", "Cuido solo perros. No me hago responsable de enfermedades.", "Alicante", "Elche", animales1, tarifas1);
                usuarioCP.CrearAnuncio ("sergito19@hotmail.com", new DateTime (2018, 04, 19), new DateTime (2018, 10, 01), "Calle Gaspar de los Cielos", "Cuido unicamente gatos y focas. No me hago responsable de enfermedades.", "Alicante", "Alicante", animales2, tarifas2);
                usuarioCP.CrearAnuncio ("danibravo@gmail.com", new DateTime (2018, 12, 19), new DateTime (2019, 01, 11), "Calle Uranio", "Soy ornitólogo así que tengo preferencia por las aves.", "Alicante", "Jijona", animales3, tarifas3);
                usuarioCP.CrearAnuncio ("imrubensi@gmail.com", new DateTime (2019, 01, 19), new DateTime (2019, 02, 01), "Calle Una Grande y Libre", "Cuido lagartos porque me encantan los reptiles. Son mis amigos", "Alicante", "San Isidro", animales4, tarifas4);
                usuarioCP.CrearAnuncio ("alexgladiator@petme.com", new DateTime (2018, 12, 20), new DateTime (2018, 12, 27), "Avenida Casa Rural", "Puedo cuidar un solo perro. En el caso de hurones puedo encargargeme de una familia de tres.", "Albacete", "Carcelén", animales5, tarifas5);
                usuarioCP.CrearAnuncio ("danibravo@gmail.com", new DateTime (2018, 12, 20), new DateTime (2019, 01, 12), "Calle Uranio", "Este anuncio es por peticion de Rubén.", "Alicante", "Jijona", animales6, tarifas6);

                // HACEMOS COMENTARIOS
                AnuncioCEN anuncioCEN = new AnuncioCEN ();
                IList<AnuncioEN> p_anuncios = anuncioCEN.ReadAll (0, -1);
                usuarioCP.HacerComentario ("danibravo@gmail.com", "¿Mi madre contaria como foca?", ValoracionEnum.buena, p_anuncios [0].Id);
                usuarioCP.HacerComentario ("alexgladiator@petme.com", "Uff... Vaya precios...", ValoracionEnum.muy_mala, p_anuncios [0].Id);

                usuarioCP.HacerComentario ("imrubensi@gmail.com", "Mi gata tiene que tomarse una medicacion y no cuesta nada np.", ValoracionEnum.muy_buena, p_anuncios [1].Id);
                usuarioCP.HacerComentario ("alexgladiator@petme.com", "Estoy interesado!", ValoracionEnum.buena, p_anuncios [1].Id);

                usuarioCP.HacerComentario ("imrubensi@gmail.com", "Sería de gran ayuda si me hicieses un descuento para halcones.", ValoracionEnum.normal, p_anuncios [2].Id);
                usuarioCP.HacerComentario ("sergito19@hotmail.com", "Podrías hacerme un pequeño descuento, lo necesito la mitad de días que tienes disponibles.", ValoracionEnum.buena, p_anuncios [2].Id);

                usuarioCP.HacerComentario ("hectorsteve@gmail.com", "Si quieres sacarte algo más de dinero con esta aplicación deberías agrandar tu abanico de cuidados.", ValoracionEnum.muy_mala, p_anuncios [3].Id);
                usuarioCP.HacerComentario ("alexgladiator@petme.com", "Este el el único anuncio que he encontrado de reptiles, pero si no cuidas cobras, me sirve de poco.", ValoracionEnum.mala, p_anuncios [3].Id);

                usuarioCP.HacerComentario ("hectorsteve@gmail.com", "La verdad es que el precio de los hurones se dispara bastante, pero estoy dispuesto a pagar por el cuidado.", ValoracionEnum.normal, p_anuncios [4].Id);

                usuarioCP.HacerComentario ("imrubensi@gmail.com", "Muchas gracias!!!", ValoracionEnum.muy_buena, p_anuncios [5].Id);


                // CONTRATAMOS ALGUNOS ANUNCIOS
                Tipo_AnimalCEN tipo_AnimalCEN = new Tipo_AnimalCEN ();
                IList<Tipo_AnimalEN> p_animales = tipo_AnimalCEN.ReadAll (0, -1);
                usuarioCP.ReservarAnuncio ("imrubensi@gmail.com", p_anuncios [5].Id, p_animales [8].Id);
                usuarioCP.ReservarAnuncio ("alexgladiator@petme.com", p_anuncios [1].Id, p_animales [4].Id);
                usuarioCP.ReservarAnuncio ("danibravo@gmail.com", p_anuncios [0].Id, p_animales [0].Id);
                usuarioCP.ReservarAnuncio ("sergito19@hotmail.com", p_anuncios [0].Id, p_animales [1].Id);
                usuarioCP.ReservarAnuncio ("imrubensi@gmail.com", p_anuncios [0].Id, p_animales [2].Id);
                usuarioCP.ReservarAnuncio ("danibravo@gmail.com", p_anuncios [3].Id, p_animales [7].Id);
                usuarioCP.ReservarAnuncio ("hectorsteve@gmail.com", p_anuncios [3].Id, p_animales [7].Id);
                usuarioCP.ReservarAnuncio ("alexgladiator@petme.com", p_anuncios [3].Id, p_animales [7].Id);

                // MODIFICAMOS ESTADO DE USUARIO
                AdministradorCP administradorCP = new AdministradorCP ();
                administradorCP.ModificarEstado ("4321@gmail.com", "danibravo@gmail.com", EstadoUsuarioEnum.suspendido, "Comentario ofensivo");

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
