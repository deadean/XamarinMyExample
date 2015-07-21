using System;

namespace PhotoTransfer.Common.Interfaces.Factories
{
	public interface IObjectsByTypeFactory
	{
		R GetObjectFromFactory<R>(object obj)
			where R : class;

		R GetObjectFromFactory<T, R>()
			where R : class;

		T GetObjectFromFactory<T>();

		void RegisterObject<T, R>(Func<T, R> func)
			where R : class;

		void RegisterObject<T, R>(Func<R> func)
			where R : class;

		void RegisterObject<T, R>()
			where R : new();
	}
}
