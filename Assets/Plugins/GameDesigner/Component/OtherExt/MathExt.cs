using System;

#if UNITY_2020_1_OR_NEWER
public static class MathExt
{
    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref byte self, int value, byte oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked((byte)(self + value)),
                1 => checked((byte)(self - value)),
                2 => checked((byte)(self * value)),
                3 => checked((byte)(self / value)),
                4 => checked((byte)(self % value)),
                5 => checked((byte)(self ^ value)),
                6 => checked((byte)(self & value)),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref sbyte self, int value, byte oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked((sbyte)(self + value)),
                1 => checked((sbyte)(self - value)),
                2 => checked((sbyte)(self * value)),
                3 => checked((sbyte)(self / value)),
                4 => checked((sbyte)(self % value)),
                5 => checked((sbyte)(self ^ value)),
                6 => checked((sbyte)(self & value)),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref short self, int value, byte oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked((short)(self + value)),
                1 => checked((short)(self - value)),
                2 => checked((short)(self * value)),
                3 => checked((short)(self / value)),
                4 => checked((short)(self % value)),
                5 => checked((short)(self ^ value)),
                6 => checked((short)(self & value)),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref ushort self, int value, byte oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked((ushort)(self + value)),
                1 => checked((ushort)(self - value)),
                2 => checked((ushort)(self * value)),
                3 => checked((ushort)(self / value)),
                4 => checked((ushort)(self % value)),
                5 => checked((ushort)(self ^ value)),
                6 => checked((ushort)(self & value)),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static int CalcRef(this ref int self, int value, byte oper)
    {
        return self = Calc(self, value, oper);
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static int Calc(this int self, int value, byte oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked(self + value),
                1 => checked(self - value),
                2 => checked(self * value),
                3 => checked(self / value),
                4 => checked(self % value),
                5 => checked(self ^ value),
                6 => checked(self & value),
                _ => throw new Exception("û�����������"),
            };
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return self;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref uint self, uint value, byte oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked(self + value),
                1 => checked(self - value),
                2 => checked(self * value),
                3 => checked(self / value),
                4 => checked(self % value),
                5 => checked(self ^ value),
                6 => checked(self & value),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref float self, float value, byte oper)
    {
        try
        {
            checked 
            {
                self = oper switch
                {
                    0 => self + value,
                    1 => self - value,
                    2 => self * value,
                    3 => self / value,
                    4 => self % value,
                    _ => throw new Exception("û�����������"),
                };
            }
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref long self, int value, int oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked(self + value),
                1 => checked(self - value),
                2 => checked(self * value),
                3 => checked(self / value),
                4 => checked(self % value),
                5 => checked(self ^ value),
                6 => checked(self & value),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref ulong self, ulong value, int oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked(self + value),
                1 => checked(self - value),
                2 => checked(self * value),
                3 => checked(self / value),
                4 => checked(self % value),
                5 => checked(self ^ value),
                6 => checked(self & value),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref double self, double value, int oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked(self + value),
                1 => checked(self - value),
                2 => checked(self * value),
                3 => checked(self / value),
                4 => checked(self % value),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }

    /// <summary>
    /// �������������������ˣ�ɶ��������
    /// </summary>
    /// <param name="self"></param>
    /// <param name="value"></param>
    /// <param name="oper">0���� 1���� 2���� 3���� 4��ȡģ 5����� 6����</param>
    /// <returns></returns>
    public static bool Calc(this ref decimal self, decimal value, int oper)
    {
        try
        {
            self = oper switch
            {
                0 => checked(self + value),
                1 => checked(self - value),
                2 => checked(self * value),
                3 => checked(self / value),
                4 => checked(self % value),
                _ => throw new Exception("û�����������"),
            };
            return true;
        }
        catch (Exception ex)
        {
            Net.Event.NDebug.LogError("�������:" + ex);
        }
        return false;
    }
}
#endif