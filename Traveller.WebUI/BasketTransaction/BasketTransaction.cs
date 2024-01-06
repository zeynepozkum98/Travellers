using Azure;
using Newtonsoft.Json;
using Traveller.WebUI.BasketTransaction.BasketModels;

namespace Traveller.WebUI.BasketTransaction
{
	public class BasketTransaction : IBasketTransaction
	{
		const string basketName = "basket";
		private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketTransaction(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

	

		public void DeleteBasket() => _httpContextAccessor.HttpContext.Response.Cookies.Delete(basketName);
	
		public void DeleteItem(int winterHolidayId)
		{
			bool response= _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(basketName);
			if(response) 
			{
				BasketDto basketDto = GetOrCreateBasket();
				BasketItemDto basketItemDto= basketDto.BasketItems.FirstOrDefault(x=>x.WinterHolidayId==winterHolidayId);
				basketDto.BasketItems.Remove(basketItemDto);
				string basketSerialize= JsonConvert.SerializeObject(basketDto);
				_httpContextAccessor.HttpContext.Response.Cookies.Append(basketName,basketSerialize);
			}	
		}

		public BasketDto GetOrCreateBasket()
		{
			bool response = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(basketName);
			return response ?
				JsonConvert.DeserializeObject<BasketDto>(_httpContextAccessor.HttpContext.Request.Cookies[basketName])
				: new BasketDto() { BasketItems = new List<BasketItemDto>() };

		}

		public void AddOrIncreaseQuantity(int winterHolidayId)
		{

			bool response = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(basketName);
			if (response)
			{
				BasketDto basketDto = GetOrCreateBasket();
				for (int i = 0; i < basketDto.BasketItems.Count; i++)
				{
					if (basketDto.BasketItems[i].WinterHolidayId == winterHolidayId && basketDto.BasketItems[i].Quantity == 1)
					{
						basketDto.BasketItems[i].Quantity += 1;
					}

					else if (basketDto.BasketItems[i].WinterHolidayId == winterHolidayId && basketDto.BasketItems[i].Quantity == 0)
					{
						basketDto.BasketItems.Remove(basketDto.BasketItems[i]);
					}
				}

				string basketSerialize = JsonConvert.SerializeObject(basketDto);
				_httpContextAccessor.HttpContext.Response.Cookies.Append(basketName, basketSerialize);
			}
		}

		public void RemoveOrDecrease(int winterHolidayId)
		{
			bool response = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(basketName);
			if(response) 
			{
				BasketDto basketDto= GetOrCreateBasket();
                for(int i = 0; i < basketDto.BasketItems.Count; i++)
                {
					if (basketDto.BasketItems[i].WinterHolidayId==winterHolidayId && basketDto.BasketItems[i].Quantity>1)
					{
						basketDto.BasketItems[i].Quantity -= 1;
					}

					else if (basketDto.BasketItems[i].WinterHolidayId==winterHolidayId && basketDto.BasketItems[i].Quantity==1)
					{
						basketDto.BasketItems.Remove(basketDto.BasketItems[i]);
					}
                }

				string basketSerialize= JsonConvert.SerializeObject(basketDto);
				_httpContextAccessor.HttpContext.Response.Cookies.Append(basketName,basketSerialize);
            }
		}

		public void SaveUpdateBasketItem(BasketItemDto basketItem)
		{
			BasketDto basketDto = GetOrCreateBasket();
			if(basketDto.BasketItems.Any(x=>x.WinterHolidayId==basketItem.WinterHolidayId))
			{
				BasketItemDto basketItemDto= basketDto.BasketItems.FirstOrDefault(x=>x.WinterHolidayId==basketItem.WinterHolidayId);
				basketItemDto.Quantity += 1;
			}
			else
			   basketDto.BasketItems.Add(basketItem);

			string basketSerialize = JsonConvert.SerializeObject(basketDto);
			_httpContextAccessor.HttpContext.Response.Cookies.Append(basketName, basketSerialize);
			
		}
	}
}
