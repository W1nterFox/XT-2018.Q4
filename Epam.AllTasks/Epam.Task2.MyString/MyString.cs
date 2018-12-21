using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.MyString
{
    public class MyString
    {
        private readonly char[] chars;
        
        public MyString(string str)
        {
            this.chars = str.ToCharArray();
        }

        public MyString(char[] chars)
        {
            this.chars = chars;
        }

        public int Length => this.chars.Length;
        
        public char this[int pos]
        {
            get
            {
                return this.chars[pos];
            }
        }

        public static MyString Concat(MyString arg0, MyString arg1)
        {
            char[] resultCharArray = new char[arg0.Length + arg1.Length];
            Array.Copy(arg0.ToCharArray(), 0, resultCharArray, 0, arg0.Length);
            Array.Copy(arg1.ToCharArray(), 0, resultCharArray, arg0.Length, arg1.Length);
            return new MyString(resultCharArray);
        }

        public static int Compare(MyString first, MyString second)
        {
            if (object.ReferenceEquals(first, second))
            {
                return 0;
            }

            if (first.Length != second.Length)
            {
                return first.Length < second.Length ? -1 : 1;
            }
            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] < second[i])
                    {
                        return -1;
                    }
                    else if (first[i] > second[i])
                    {
                        return 1;
                    }
                }

                return 0;
            }
        }

        public static MyString operator +(MyString first, MyString second)
        {
            return MyString.Concat(first, second);
        }

        public static bool operator ==(MyString first, MyString second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(MyString first, MyString second)
        {
            return !(first == second);
        }

        public static implicit operator MyString(string str)
        {
            return new MyString(str) ?? null;
        }

        public override string ToString()
        {
            return new string(this.ToCharArray());
        }

        public MyString Insert(MyString myStr, int pos)
        {
            if (pos < 0 || pos > this.Length)
            {
                throw new ArgumentOutOfRangeException("Target position must be positive and less than length of MyString");
            }

            char[] res = new char[this.Length + myStr.Length];
            Array.Copy(this.ToCharArray(), 0, res, 0, pos);
            Array.Copy(myStr.ToCharArray(), 0, res, pos, myStr.Length);
            Array.Copy(this.ToCharArray(), pos, res, pos + myStr.Length, this.Length - pos);

            return new MyString(res);
        }

        public MyString ToUpper()
        {
            char[] res = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                res[i] = char.ToUpper(this[i]);
            }

            return new MyString(res);
        }

        public MyString ToLower()
        {
            char[] res = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                res[i] = char.ToLower(this[i]);
            }

            return new MyString(res);
        }

        public char[] ToCharArray()
        {
            char[] returnCharArray = new char[this.Length];
            Array.Copy(this.chars, 0, returnCharArray, 0, this.Length);
            return returnCharArray;
        }
        
        public int CompareTo(MyString myStr)
        {
            return MyString.Compare(this, myStr);
        }

        public bool Contains(MyString str)
        {
            if (this.Length < str.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.Length - str.Length + 1; i++)
                {
                    bool charNotEqualsAtLeastOnce = false;
                    for (int k = 0; k < str.Length; k++)
                    {
                        if (this[i + k] != str[k])
                        {
                            charNotEqualsAtLeastOnce = true;
                            break;
                        }
                    }

                    if (!charNotEqualsAtLeastOnce)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool StartsWith(MyString str)
        {
            if (this.Length < str.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (this[i] != str[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool EndsWith(MyString str)
        {
            if (this.Length < str.Length)
            {
                return false;
            }
            else
            {
                int indexThis = this.Length - str.Length;
                for (int i = 0; i < str.Length; i++, indexThis++)
                {
                    if (this[indexThis] != str[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public int CountCertainSymbol(char ch)
        {
            int count = 0;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == ch)
                {
                    count++;
                }
            }

            return count;
        }

        public int CountCertainSymbolAtTheBegin(char ch)
        {
            int count = 0;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == ch)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        public int CountCertainSymbolAtTheEnd(char ch)
        {
            int count = 0;
            for (int i = this.Length - 1; i > 0; i--)
            {
                if (this[i] == ch)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        public MyString Trim()
        {
            char space = ' ';
            int countLeftSpace = this.CountCertainSymbolAtTheBegin(space);
            int countRightSpace = this.CountCertainSymbolAtTheEnd(space);
            int lengthOfResChar = this.Length - countLeftSpace - countRightSpace;
            char[] resChar = new char[lengthOfResChar];
            Array.Copy(this.ToCharArray(), countLeftSpace, resChar, 0, lengthOfResChar);
            return new MyString(resChar);
        }

        public MyString TrimStart()
        {
            char space = ' ';
            int countLeftSpace = this.CountCertainSymbolAtTheBegin(space);
            int lengthOfResChar = this.Length - countLeftSpace;
            char[] resChar = new char[lengthOfResChar];
            Array.Copy(this.ToCharArray(), countLeftSpace, resChar, 0, lengthOfResChar);
            return new MyString(resChar);
        }

        public MyString TrimEnd()
        {
            char space = ' ';
            int countRightSpace = this.CountCertainSymbolAtTheEnd(space);
            int lengthOfResChar = this.Length - countRightSpace;
            char[] resChar = new char[lengthOfResChar];
            Array.Copy(this.ToCharArray(), 0, resChar, 0, lengthOfResChar);
            return new MyString(resChar);
        }

        public int IndexOf(char value)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(char value)
        {
            for (int i = this.Length - 1; i > 0; i--)
            {
                if (this[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public char CharAt(int index)
        {
            if (index < 0 || index > this.Length - 1)
            {
                throw new IndexOutOfRangeException("Index must be positive and less than length of MyString");
            }

            return this[index];
        }

        public bool Equals(MyString myStr)
        {
            if (object.ReferenceEquals(null, myStr))
            {
                return false;
            }

            if (object.ReferenceEquals(this, myStr))
            {
                return true;
            }

            if (this.Length != myStr.Length)
            {
                return false;
            }

            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != myStr[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
