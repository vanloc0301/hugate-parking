namespace Hugate.Camera
{
	using System;
	using System.Collections;

	/// <summary>
	/// ViewCollection class
	/// </summary>
	public class ViewCollection : CollectionBase
	{
		// Constructor
		public ViewCollection()
		{
		}

		// Get view at the specified index
		public View this[int index]
		{
			get
			{
				return ((View) InnerList[index]);
			}
		}

		// Add new view to the collection
		public void Add(View view)
		{
			InnerList.Add(view);
		}

		// Remove view from the collection
		public void Remove(View view)
		{
			InnerList.Remove(view);
		}

		// Get view with specified name
		public View GetView(string name, Group parent)
		{
			// find the view
			foreach (View view in InnerList)
			{
				if ((view.Name == name) && (view.Parent == parent))
					return view;
			}
			return null;
		}

        public View GetViewSingle(string name)
        {
            // find the view
            foreach (View view in InnerList)
            {
                if (view.Name == name)
                    return view;
            }
            return null;
        }
	}
}
