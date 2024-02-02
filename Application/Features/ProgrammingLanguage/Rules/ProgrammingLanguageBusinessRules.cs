using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<PLanguage> result = await _programmingLanguageRepository.GetListAsync(( b) => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("ProgrammingLanguage name exists.");
        }
        public void ProgrammingLanguageShouldExistWhenRequested(PLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested brand does not exist");
        }
    }
}