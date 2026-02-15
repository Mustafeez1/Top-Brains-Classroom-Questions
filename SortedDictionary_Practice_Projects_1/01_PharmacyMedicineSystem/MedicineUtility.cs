// namespace Services
// {
using System.Collections.Generic;
    class MedicineUtility 
{
    public SortedDictionary<int, List<Medicine>> AvailableMedicines = new SortedDictionary<int, List<Medicine>>();
    public void AddMedicine(Medicine medicine)
    {
        if (AvailableMedicines.ContainsKey(medicine.ExpiryYear))
        {
            AvailableMedicines[medicine.ExpiryYear].Add(medicine);
        }
        else
        {
            AvailableMedicines.Add(medicine.ExpiryYear, new List<Medicine>{medicine});
        }
    }
    public void GetAllMedicines()
    {
        foreach (var item in AvailableMedicines)
        {
            Console.Write($"{item.Key}");
            foreach (var list in item.Value)
            {
                Console.Write($"Id: {list.Id} Name : {list.Name} Price: {list.Price} ExpiryYear: {list.ExpiryYear}");
            }
        }
    }
    public void UpdateMedicinePrice(string id, int newPrice)
    {
        // if(newPrice < 0 ) throw new InvalidPriceException("Price must be grater than 0");
        // bool IsFound = false;
        foreach(var item in AvailableMedicines.Values)
        {
            var query = item.FirstOrDefault(i => i.Id == id);
            if(query != null)
            {
                query.Price = newPrice;
                // IsFound = true;
                break;
            }
        }
        // if(!IsFound) throw new MeedicineNotFoundException("Medicine was not found");

    }
}
// }