using DataLayer.Entities;
using System.Collections.Generic;
using System.Data;
using WebTasks.Models;

namespace WebTasks.Services
{
    public class DirectoryService
    {
        private readonly IDataBaseAdapter Context;
        public DirectoryService(IDataBaseAdapter context)=>Context = context;

        public List<DirectoryViewModel> GetAllDirectories()
        {
            var DirectoryList = Context.GetAllDirectories();
            List < DirectoryViewModel> directoryViewModels = new List<DirectoryViewModel>();
            foreach (var item in DirectoryList)
            {
                directoryViewModels.Add(new DirectoryViewModel(){ 
                    Id=item.Id,
                    Directory=item,
                    Tasks=item.MyTasks,
                    Title=item.Title});
            }
            return directoryViewModels;

        }
        public DirectoryViewModel GetDirectory(int id)
        {
            var model = Context.GetDirectory(id);
            return new DirectoryViewModel() {
                Id = model.Id,
                Directory = model,
                Tasks =  model.MyTasks,
                Title = model.Title
            };
        }
        public void EditDirectory(DirectoryEditModel model) {
            var ReplaceMoedel = new Directory() { 
                Id = model.Id, 
                Title=model.Title};
            Context.EditDirectoryTitle(ReplaceMoedel);
         }
        public void DeleteDirectory(DirectoryEditModel model)
        {
            var ReplaceMoedel = new Directory() {Id = model.Id,};
            Context.DeleteDirectory(ReplaceMoedel);
        }
        public void AddDirectory(DirectoryEditModel model)
        {
            var AddMoedel = new Directory()
            {
                Id = model.Id,
                Title = model.Title
            };
            Context.AddDirectory(AddMoedel);
        }
    }
}
