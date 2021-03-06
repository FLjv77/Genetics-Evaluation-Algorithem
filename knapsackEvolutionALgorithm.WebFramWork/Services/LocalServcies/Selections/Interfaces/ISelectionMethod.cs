﻿using knapsackEvolutionALgorithm.Service.Entities;
using System.Threading.Tasks;

namespace knapsackEvolutionALgorithm.Service.Services.LocalServcies.Interfaces
{
    /// <summary>
    /// واسط انتخاب
    /// </summary>
    /// <typeparam name="TSelectionBox">از چه چیزی قراره انتخاب انجام شود</typeparam>
    /// <typeparam name="TResponse">خروجی در چه فرمتی خوهد بود</typeparam>
    public interface ISelectionMethod<in TSelectionBox, TResponse>
        where TSelectionBox : class
    {
        Task<TResponse> HandleSelection(TSelectionBox SelectionBoxs, int capacity, Selection selection);
    }
}
    