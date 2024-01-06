using Traveller.WebUI.BasketTransaction.BasketModels;

namespace Traveller.WebUI.BasketTransaction
{
	public interface IBasketTransaction
	{
		BasketDto GetOrCreateBasket();
		void SaveUpdateBasketItem(BasketItemDto basketItem);
		void RemoveOrDecrease(int winterHolidayId);
		void AddOrIncreaseQuantity(int winterHolidayId);
		void DeleteItem(int winterHolidayId);
		void DeleteBasket();
	}
}
