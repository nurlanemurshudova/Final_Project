using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class TeacherCandidateManager : ITeacherCandidateService
    {
        TeacherCandidateDal teacherCandidateDal = new();
        public IResult Add(TeacherCandidate entity)
        {
            teacherCandidateDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            teacherCandidateDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<TeacherCandidate>> GetAll()
        {
            return new SuccessDataResult<List<TeacherCandidate>>(teacherCandidateDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<TeacherCandidate> GetById(int id)
        {
            return new SuccessDataResult<TeacherCandidate>(teacherCandidateDal.GetById(id));
        }

        public IResult Update(TeacherCandidate entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            teacherCandidateDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
