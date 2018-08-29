using SuggeBook.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuggeBook.Business.Contracts
{
    public abstract class BaseInteractor
    {
        private IBaseDataService _dataService;

        public virtual T2 Get<T1, T2>(string id)
        {
            var dao = _dataService.Get(id);
            var dto = SuggeBookAutoMapper.Map<T1, T2>(dao);


        }
    }
}
