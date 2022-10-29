using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.AdminPortal.Pages
{
    public partial class MotorcycleDetailsPage : ComponentBase
    {

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IGetMotorcycleUseCase MotorcycleUseCase { get; set; }

        [Inject]
        private IRemoveMotorcycleUseCase RemoveMotorcycleUseCase { get; set; }

        private IMotorcycle motorcycle;
        

        [Inject]
        private IBreadcrumbService _breadcrumbService { get; set; }
        public List<IBreadcrumb> Breadcrumbs { get; set; }

        private List<string> images = new List<string>();


        private string MessageTitle;
        private string Message;
        private string MessageType;


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.motorcycle = await this.MotorcycleUseCase.Execute(this.Id);
            this.images = this.GetImages(this.motorcycle.ImagesGalleryUrls);


            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = $"{this.motorcycle.Make} / {this.motorcycle.Model}",
                Url = $"/motorcycle/{this.motorcycle.Id}"
            };

            this.Breadcrumbs = this._breadcrumbService.GetBreadcrumb(breadcrumb);

            this.MessageTitle = "Delete Motorcycle";
            this.Message = $"Are you sure you want to DELETE: {this.motorcycle.Make} {this.motorcycle.Model}?";
            this.MessageType = "warning";
        }

        private List<string> GetImages(string imagesUrlsString)
        {
            if(string.IsNullOrEmpty(imagesUrlsString)) return new List<string>();

            return imagesUrlsString.Split(',').ToList();
        }



        private void ClickHandler(bool agreeToDeleteMotorcycle)
        {
            this.RemoveMotorcycleUseCase.Execute(this.motorcycle.Id);

            this.NavigationManager.NavigateTo("/");
        }




    }
}
