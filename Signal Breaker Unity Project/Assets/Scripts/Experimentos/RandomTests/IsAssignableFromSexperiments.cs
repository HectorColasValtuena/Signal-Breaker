using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAssignableFromSexperiments : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("========\nIsAssignableFromSexperiments:\n========");
		TestClass1 testObj1 = new TestClass1();
		TestClass2 testObj2 = new TestClass2();
		TestClass3 testObj3 = new TestClass3();
		ITest1 testObj3b = testObj3;
		TestClass1B testObj1B = new TestClass1B();


		//==//
		Debug.Log("== Direct comparison");
		Debug.Log("testObj1 is ITest1 ¿true?");
		Debug.Log(testObj1 is ITest1);
		Debug.Log("testObj1 is ITest1B ¿false?");
		Debug.Log(testObj1 is ITest1B);

		Debug.Log("typeof(ITest1).IsAssignableFrom(typeof(TestClass1)) ¿true?");
		Debug.Log(typeof(ITest1).IsAssignableFrom(typeof(TestClass1)));
		Debug.Log("typeof(ITest2).IsAssignableFrom(typeof(TestClass1)) ¿false?");
		Debug.Log(typeof(ITest2).IsAssignableFrom(typeof(TestClass1)));
		Debug.Log("");

		Debug.Log("== False positive comparison");
		Debug.Log("typeof(ITest1B).IsAssignableFrom(typeof(TestClass1)) ¿false?");
		Debug.Log(typeof(ITest1B).IsAssignableFrom(typeof(TestClass1)));
		Debug.Log("");

		Debug.Log("== Cross-type comparison");
		Debug.Log("==== Acessed as class");
		Debug.Log("typeof(ITest1).IsAssignableFrom(typeof(TestClass3)) ¿true?");
		Debug.Log(typeof(ITest1).IsAssignableFrom(typeof(TestClass3)));
		Debug.Log("typeof(ITest2).IsAssignableFrom(typeof(TestClass3)) ¿true?");
		Debug.Log(typeof(ITest2).IsAssignableFrom(typeof(TestClass3)));
		Debug.Log("typeof(ITest1B).IsAssignableFrom(typeof(TestClass3)) ¿false?");
		Debug.Log(typeof(ITest1B).IsAssignableFrom(typeof(TestClass3)));
		Debug.Log("");

		Debug.Log("==== Accessed as object");
		Debug.Log("(testObj3 is ITest1) && (testObj3 is ITest2) ¿true?");
		Debug.Log((testObj3 is ITest1) && (testObj3 is ITest2));
		Debug.Log("testObj3b is ITest2 ¿true? <!!");
		Debug.Log(testObj3b is ITest2);

	}

}

public interface ITest1 {
	int Test1 { get; set; }
}

public interface ITest2 {
	int Test2 { get; set; }
}

public interface ITest1B {
	int Test1 { get; set; }
}


public class TestClass1 : ITest1 {
	public int Test1 { get { return 0; } set {} }
}
public class TestClass2 : ITest2 {
	public int Test2 { get { return 0; } set {} }
}
public class TestClass3 : ITest1, ITest2 {
	public int Test1 { get { return 0; } set {} }
	public int Test2 { get { return 0; } set {} }
}
public class TestClass1B : ITest1B {
	public int Test1 { get { return 0; } set {} }
}