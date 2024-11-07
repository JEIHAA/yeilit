using System;
class Program
{
    class Error : Exception {
        public virtual void Message() {
            Console.WriteLine("Error");
        }
    }

    class ArrayError : Error{
        public override void Message() {
            Console.WriteLine("Array Error");
        }
    }
    class VariableError: Error
    {
        public override void Message()
        {
            Console.WriteLine("Variable Error");
        }
    }

    public static void Main(string[] _args)
    {
        // 예외처리(Exception)
        // try ~ catch
        Console.WriteLine("Begin");
        try
        {

            // 스택 되감기(Stack Unwinding) 에러를 만나서 빠져나갈때 만들어진 변수를 전부 stack에서 제거한다
            // 동적할당해준 경우 해제하기 전에 변수를 지워버리기 때문에 메모리가 미아되는 경우가 있어 신경써야함
            Console.WriteLine("Before");
            //throw new VariableError();
            int[] arr = new int[5];
            //arr[7] = 10;
            if (arr.Length > 0)
                throw new NullReferenceException(); // 이미 만들어진것들도 있음 이거 쓰던지 새로 만들어서 쓰던지. 새로 만들때는 Exception만 상속받게 만들면 됨
            Console.WriteLine("Before");
        }
        catch (Error _error)
        {
            _error.Message();
        }
        /*catch(ArrayError _error) { //Exception 클래스를 상속받은 놈들은 catch로 들어갈 수 있음
            //Console.WriteLine("Gotcha!");
            _error.Message();
        }
        catch (VariableError _error)
        { 
            _error.Message();
        }*/
        finally { //try에서 에러가 발생해서 catch로 들어가던지 throw로 catch에 던지던지 finally에는 무조건 들어감
            Console.WriteLine("Finally");
        }
        Console.WriteLine("End");
    }
}