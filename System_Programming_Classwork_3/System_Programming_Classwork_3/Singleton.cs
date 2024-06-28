namespace System_Programming_Classwork_3
{
    internal class Singleton
    {
        private static Singleton instance;

        public static Singleton getInstance()
        {
            if (instance != null) return instance;

            lock (typeof(Singleton))
            {
                if (instance != null) return instance;
                instance = new Singleton();
            }
            return instance;
        }
    }
}
