using cc105_pose_proj.Data;
using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;
using cc105_pose_proj.Services;
using cc105_pose_proj.Services.Interfaces;
using cc105_pose_proj.UserControls;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace cc105_pose_proj
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, e) => HandleException(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    HandleException(ex);
                }
            };

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Application.Run(new MainForm(ServiceProvider));
        }

        private static void HandleException(Exception ex)
        {
            if (ex is MySqlException sqlEx && IsConnectionError(sqlEx))
            {
                MessageBox.Show(
                    @$"Unable to communicate with the database. (Error Code: {sqlEx.Number})",
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            MessageBox.Show(
                $"An unexpected error occurred and was handled by the application: {ex.Message}", 
                "Error", 
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private static bool IsConnectionError(MySqlException ex)
        {
            return ex.Number switch
            {
                0 => true,    // unable to connect to serv
                1042 => true, // unable to connecto to host
                2002 => true, // conn timed out
                2003 => true, // cont connect to mysql serv
                2006 => true, // mysql server is gone, reduced to atoms
                2013 => true, // lost connection during query
                _ => false
            };
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDialogService, DialogService>();

            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Discount>, DiscountRepository>();
            services.AddScoped<IRepository<Business>, BusinessRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<InventoryMovement>, InventoryMovementRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IInventoryMovementService, InventoryMovementService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            services.AddTransient<MainForm>();
            services.AddTransient<PopupForm>();
            services.AddTransient<Login>();
            services.AddTransient<ProfileSettingView>();
        }
    }
}