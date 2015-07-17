namespace Common.Delegates
{
    public delegate T T_Void<T>();
    public delegate T T_Object<T>(object obj);
    public delegate T T_Objects<T>(params object[] obj);
    public delegate T T_Z<T, Z>(Z obj);
    public delegate T T_Zs<T, Z>(params Z[] obj);
}
