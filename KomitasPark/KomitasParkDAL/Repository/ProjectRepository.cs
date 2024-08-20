using KomitasPark.KomitasParkDAL.Data;
using KomitasPark.KomitasParkDAL.Entites;
using KomitasPark.KomitasParkDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KomitasPark.KomitasParkDAL.Repository
{
    public class ProjectRepository : AbstractRepository, IProjectRepository
    {
        private readonly DbSet<Project> _dbSet;

        public ProjectRepository(RealEstateContext context) : base(context)
        {
            _dbSet = context.Set<Project>();
        }

        public void Add(Project entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

            _dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Project entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

            try
            {
                _dbSet.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0.");

            var project = _dbSet
                .Include(p => p.BuildingGroups)
                    .ThenInclude(bg => bg.Buildings)
                        .ThenInclude(b => b.Rooms)
                            .ThenInclude(r => r.Elements)
                .FirstOrDefault(p => p.Id == id);

            if (project == null)
                throw new InvalidOperationException($"No project found with ID {id}.");

            try
            {
                _dbSet.Remove(project);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Project> GetAll()
        {
            return _dbSet
                .Include(p => p.BuildingGroups)
                    .ThenInclude(bg => bg.Buildings)
                        .ThenInclude(b => b.Rooms)
                            .ThenInclude(r => r.Elements)
                .ToList();
        }

        public IEnumerable<Project> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _dbSet
                .Include(p => p.BuildingGroups)
                    .ThenInclude(bg => bg.Buildings)
                        .ThenInclude(b => b.Rooms)
                            .ThenInclude(r => r.Elements)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Project? GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0.");

            return _dbSet
                .Include(p => p.BuildingGroups)
                    .ThenInclude(bg => bg.Buildings)
                        .ThenInclude(b => b.Rooms)
                            .ThenInclude(r => r.Elements)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Update(Project entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

            var existingProject = _dbSet
                .Include(p => p.BuildingGroups)
                    .ThenInclude(bg => bg.Buildings)
                        .ThenInclude(b => b.Rooms)
                            .ThenInclude(r => r.Elements)
                .FirstOrDefault(p => p.Id == entity.Id);

            if (existingProject == null)
                throw new InvalidOperationException($"Project with ID {entity.Id} not found.");

            try
            {
                _dbSet.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}