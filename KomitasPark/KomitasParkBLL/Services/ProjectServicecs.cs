using KomitasPark.KomitasParkBLL.Interfaces;
using KomitasPark.KomitasParkBLL.Models;
using KomitasPark.KomitasParkDAL.Entites;
using KomitasPark.KomitasParkDAL.Interfaces;

namespace KomitasPark.Services
{
    public class ProjectService : ICrud<AbstractModel>
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Add(AbstractModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var projectModel = (ProjectModel)model;
            var project = new Project(projectModel.Id, projectModel.Name ?? string.Empty, projectModel.Code ?? string.Empty);
            _repository.Add(project);
        }

        public void Delete(int modelId)
        {
            if (modelId <= 0)
                throw new ArgumentOutOfRangeException(nameof(modelId), "Model ID must be greater than zero.");

            try
            {
                _repository.DeleteById(modelId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while deleting the project.", ex);
            }
        }

        public IEnumerable<AbstractModel> GetAll()
        {
            return _repository.GetAll()
                .Select(x => new ProjectModel(x.Id, x.Name ?? string.Empty, x.Code ?? string.Empty));
        }

        public AbstractModel GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");

            var project = _repository.GetById(id);
            if (project == null)
                throw new KeyNotFoundException($"Project with ID {id} not found.");

            return new ProjectModel(project.Id, project.Name ?? string.Empty, project.Code ?? string.Empty);
        }

        public void Update(AbstractModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var projectModel = (ProjectModel)model;
            var project = new Project(projectModel.Id, projectModel.Name ?? string.Empty, projectModel.Code ?? string.Empty);

            _repository.Update(project);
        }
    }
}