using System.Collections;
using System.Collections.Generic;

namespace provide.Model.Client
{
    public class ProvideGetListResponse<BaseModel>: ProvideResponse, IList<BaseModel>
    {
        public ProvideGetListResponse()
        {
            ResponseList = new List<BaseModel>();
        }

        public BaseModel this[int index] { get => ((IList<BaseModel>)ResponseList)[index]; set => ((IList<BaseModel>)ResponseList)[index] = value; }


        // name is pretty bad just trying out at this point
        public List<BaseModel> ResponseList { get; set; }

        public int Count => ((ICollection<BaseModel>)ResponseList).Count;

        public bool IsReadOnly => ((ICollection<BaseModel>)ResponseList).IsReadOnly;

        public void Add(BaseModel item)
        {
            ((ICollection<BaseModel>)ResponseList).Add(item);
        }

        public void Clear()
        {
            ((ICollection<BaseModel>)ResponseList).Clear();
        }

        public bool Contains(BaseModel item)
        {
            return ((ICollection<BaseModel>)ResponseList).Contains(item);
        }

        public void CopyTo(BaseModel[] array, int arrayIndex)
        {
            ((ICollection<BaseModel>)ResponseList).CopyTo(array, arrayIndex);
        }

        public IEnumerator<BaseModel> GetEnumerator()
        {
            return ((IEnumerable<BaseModel>)ResponseList).GetEnumerator();
        }

        public int IndexOf(BaseModel item)
        {
            return ((IList<BaseModel>)ResponseList).IndexOf(item);
        }

        public void Insert(int index, BaseModel item)
        {
            ((IList<BaseModel>)ResponseList).Insert(index, item);
        }

        public bool Remove(BaseModel item)
        {
            return ((ICollection<BaseModel>)ResponseList).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<BaseModel>)ResponseList).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)ResponseList).GetEnumerator();
        }
    }
}
