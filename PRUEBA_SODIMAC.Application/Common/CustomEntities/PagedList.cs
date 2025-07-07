// <copyright file="PagedList.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Application.Common.CustomEntities
{
	public class PagedList<T> : List<T>
	{
		public PagedList() { }

		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			AddRange(items);
		}

		public int CurrentPage { get; set; }

		public int TotalPages { get; set; }

		public int PageSize { get; set; }

		public int TotalCount { get; set; }

		public bool HasPreviousPage => CurrentPage > 1;

		public bool HasNextPage => CurrentPage < TotalPages;

		public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : null;

		public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : null;

		public static PagedList<T> Create(IEnumerable<T> source, int pageNumber,
			int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize)
				.ToList();
			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}
