﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Quote.Model;

namespace VirtoCommerce.Domain.Quote.Services
{
	public interface IQuoteRequestService
	{
        GenericSearchResult<QuoteRequest> Search(QuoteRequestSearchCriteria criteria);

        IEnumerable<QuoteRequest> GetByIds(params string[] ids);
		IEnumerable<QuoteRequest> SaveChanges(QuoteRequest[] quoteRequests);
		void Delete(string[] ids);
	}
}
