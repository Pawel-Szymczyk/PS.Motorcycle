using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.AdminPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Services;

namespace PS.Motorcycle.UserPortal.Pages
{
    public partial class MotorcycleDetailsPage : ComponentBase
    {
        #region Parameters ------------------------------------------------------
        [Parameter]
        public Guid Id { get; set; }
        #endregion

        #region Use Cases and Services ------------------------------------------
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        private IGetMotorcycleUseCase MotorcycleUseCase { get; set; } = default!;

        //[Inject]
        //private IRemoveMotorcycleUseCase RemoveMotorcycleUseCase { get; set; } = default!;

        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; } = default!;
        #endregion

        #region Properties ------------------------------------------------------
        private List<IBreadcrumb>? Breadcrumbs { get; set; }

        private List<string> images = new List<string>();

        private IMotorcycle? motorcycle = null;

        //private string messageTitle = string.Empty;
        //private string message = string.Empty;
        //private string messageType = string.Empty;
        private string editPath = string.Empty;
        #endregion

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            this.motorcycle = await this.MotorcycleUseCase.Execute(this.Id);
            this.images = this.GetImages(this.motorcycle.ImagesGalleryUrls);


            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = $"{this.motorcycle.Make} / {this.motorcycle.Model}",
                Url = $"/motorcycle/{this.motorcycle.Id}"
            };

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);

            this.editPath = $"/motorcycle/edit/{this.motorcycle.Id}";

            //this.messageTitle = "Delete Motorcycle";
            //this.message = $"Are you sure you want to DELETE: {this.motorcycle.Make} {this.motorcycle.Model}?";
            //this.messageType = "alert alert-danger";
        }

        
        //protected void ClickHandler(bool agreeToDeleteMotorcycle)
        //{
        //    this.RemoveMotorcycleUseCase.Execute(this.motorcycle.Id);

        //    this.NavigationManager.NavigateTo("/");
        //}


        private List<string> GetImages(string imagesUrlsString)
        {
            if (string.IsNullOrEmpty(imagesUrlsString)) return new List<string>();

            return imagesUrlsString.Split(',').ToList();
        }

    }
}
