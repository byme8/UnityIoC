using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using IoC;

public class ContainerDependencyTest 
{
	[Test]
	public void CheckDependencyContainer()
	{
		Dependency<ISettingsManager> settings = new Dependency<ISettingsManager>();
		
		Assert.AreEqual(settings.Value.Name, "Jek");
	}
}
