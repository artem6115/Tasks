using System.Collections.Generic;
using WebTasks.Models;
using WebTasks.Data.DataLayer;
using DataLayer.Entities;
using System;

namespace WebTasks.Services
{
    public class TasksService
    {
        private readonly IDataBaseAdapter Context;
        public TasksService(IDataBaseAdapter context) => Context = context;

        public TasksViewModel GetTask(int id)
        {
            var model = Context.GetTask(id);
            return new TasksViewModel()
            {
                Id = model.Id,
                Title = model.Title,
            };
        }
        public void EditTask(TasksEditModel model)
        {
            var Dir = Context.GetDirectory(model.DirectoryId);
            if (Dir == null)
            {
                throw new Exception("Указаной директории для записи не существует");
            }
            var AddMoedel = new Tasks()
            {
                Id = model.Id,
                Title = model.Title,
                Directory = Dir

            };
            Context.EditTask(AddMoedel);
        }
        public void DeleteTask(TasksEditModel model)
        {
            var Dir = Context.GetDirectory(model.DirectoryId);
            var Moedel = new Tasks()
            {
                Id = model.Id,
                Title = model.Title,
                Directory = Dir

            };
            Context.DeleteTask(Moedel);
        }

        public void AddTask(TasksEditModel model)
        {
            var Dir = Context.GetDirectory(model.DirectoryId);
            if(Dir == null)
            {
                throw new Exception("Указаной директории для записи не существует");
            }
            var AddMoedel = new Tasks()
            {
                Id = model.Id,
                Title = model.Title,
                Directory=Dir

            };
            Context.AddTask(AddMoedel);
        }
    }
}
