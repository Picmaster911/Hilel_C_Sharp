using DAL;
using HomeWork_Asp_Net_MVC.ViewModels;
using MyNoteProcessor;
using NoteContracs;

namespace HomeWork_Asp_Net_MVC.Extantion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            services.AddScoped<IDataWorker<MyNote>, DataWorker>();
            services.AddScoped<INoteProcessor, NoteProcessor>();
            services.AddScoped<NotesViewModel>();
            return services;
        }
    }
}
