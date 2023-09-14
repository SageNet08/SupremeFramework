﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SupremeFramework.Features.API
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("API_TEST_TEMPLATE")]
    public partial class API_TEST_TEMPLATEFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ApiFeatures.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/API", "API_TEST_TEMPLATE", "This is a general outline of how the API tests can be written and reused.\r\n\r\n//Re" +
                    "source Allocation ", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 8
#line hidden
#line 9
 testRunner.And("the user sets the baseUrl \"https://localhost:44339/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "methodType",
                        "urlParameter",
                        "urlResourceValue",
                        "requestBody"});
            table1.AddRow(new string[] {
                        "POST",
                        "api/authenticate",
                        "null",
                        "PostCredentials"});
#line 10
 testRunner.And("an API request is made", ((string)(null)), table1, "* ");
#line hidden
#line 13
 testRunner.When("the request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 14
 testRunner.Then("authenication token is saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Request for CatalogItemID")]
        [NUnit.Framework.CategoryAttribute("TheGreatSage")]
        public virtual void GetRequestForCatalogItemID()
        {
            string[] tagsOfScenario = new string[] {
                    "TheGreatSage"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Request for CatalogItemID", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
this.FeatureBackground();
#line hidden
#line 19
    testRunner.Given("user has authenticaion token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "methodType",
                            "urlParameter",
                            "urlResourceValue",
                            "requestBody"});
                table2.AddRow(new string[] {
                            "GET",
                            "api/catalog-items/{catalogItemId}",
                            "1",
                            "noBody"});
#line 20
 testRunner.Given("an API request is made", ((string)(null)), table2, "Given ");
#line hidden
#line 23
 testRunner.When("the request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then("the \"GetCatalogItemIdResp\" type is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.Then("the Status Code \"200\" should be received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "name",
                            "price",
                            "pictureUri",
                            "catalogTypeId",
                            "catalogBrandId"});
                table3.AddRow(new string[] {
                            "1",
                            ".NET Bot Black Sweatshirt",
                            "19.50",
                            "/images/products/1.png",
                            "2",
                            "2"});
#line 26
 testRunner.Then("the response is verified for the following fields", ((string)(null)), table3, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Post Request")]
        public virtual void PostRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Post Request", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
this.FeatureBackground();
#line hidden
#line 35
     testRunner.Given("user has authenticaion token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "methodType",
                            "urlParameter",
                            "urlResourceValue",
                            "requestBody"});
                table4.AddRow(new string[] {
                            "POST",
                            "api/catalog-items/",
                            "null",
                            "PostRequestCatalogJson"});
#line 36
  testRunner.Given("an API request is made", ((string)(null)), table4, "Given ");
#line hidden
#line 39
  testRunner.When("the request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
  testRunner.Then("the \"PostCatalogItemResp\" type is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
  testRunner.And("the Status Code \"201\" should be received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "name",
                            "price",
                            "pictureUri",
                            "catalogTypeId",
                            "catalogBrandId"});
                table5.AddRow(new string[] {
                            "57",
                            "OLD",
                            "10",
                            "images\\products\\eCatalog-item-default.png?0",
                            "2",
                            "2"});
#line 42
  testRunner.Then("the response is verified for the following fields", ((string)(null)), table5, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete Request")]
        public virtual void DeleteRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Request", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 47
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
this.FeatureBackground();
#line hidden
#line 48
     testRunner.Given("user has authenticaion token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "methodType",
                            "urlParameter",
                            "urlResourceValue",
                            "requestBody"});
                table6.AddRow(new string[] {
                            "DELETE",
                            "api/catalog-items/{catalog-ItemsId}",
                            "51",
                            "noBody"});
#line 49
  testRunner.And("an API request is made", ((string)(null)), table6, "* ");
#line hidden
#line 52
  testRunner.When("the request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 53
  testRunner.Then("the \"DeleteCatalogIdResponse\" type is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
  testRunner.And("the Status Code \"200\" should be received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "status"});
                table7.AddRow(new string[] {
                            "Deleted"});
#line 55
  testRunner.Then("the DELETE response is verified for the following field", ((string)(null)), table7, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Put Request")]
        public virtual void PutRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Put Request", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 61
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
this.FeatureBackground();
#line hidden
#line 62
 testRunner.Given("user has authenticaion token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "methodType",
                            "urlParameter",
                            "urlResourceValue",
                            "requestBody"});
                table8.AddRow(new string[] {
                            "PUT",
                            "api/catalog-items/",
                            "null",
                            "PutRequest"});
#line 63
  testRunner.And("an API request is made", ((string)(null)), table8, "* ");
#line hidden
#line 66
  testRunner.When("the request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 67
  testRunner.Then("the \"PutResponse\" type is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 68
  testRunner.And("the Status Code \"200\" should be received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "name",
                            "price",
                            "pictureUri",
                            "catalogTypeId",
                            "catalogBrandId"});
                table9.AddRow(new string[] {
                            "57",
                            "NEW",
                            "10",
                            "images\\products\\eCatalog-item-default.png?0",
                            "2",
                            "2"});
#line 69
  testRunner.Then("the response is verified for the following fields", ((string)(null)), table9, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Request By Page")]
        public virtual void GetRequestByPage()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Request By Page", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 75
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
this.FeatureBackground();
#line hidden
#line 76
 testRunner.Given("user has authenticaion token", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "methodType",
                            "urlParameter",
                            "urlResourceValue",
                            "requestBody"});
                table10.AddRow(new string[] {
                            "GET",
                            "api/catalog-items/",
                            "null",
                            "GetRequestByPageJson"});
#line 77
 testRunner.And("an API request is made", ((string)(null)), table10, "* ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "key",
                            "value"});
                table11.AddRow(new string[] {
                            "pageSize",
                            "1"});
                table11.AddRow(new string[] {
                            "pageIndex",
                            "1"});
                table11.AddRow(new string[] {
                            "catalogBrandId",
                            "2"});
                table11.AddRow(new string[] {
                            "catalogTypeId",
                            "2"});
#line 80
   testRunner.And("the user adds query parameters to the request", ((string)(null)), table11, "And ");
#line hidden
#line 86
  testRunner.When("the request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 87
  testRunner.Then("the GetRequestByPage type is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 88
  testRunner.And("the Status Code \"200\" should be received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "name",
                            "price",
                            "pictureUri",
                            "catalogTypeId",
                            "catalogBrandId",
                            "pageCount"});
                table12.AddRow(new string[] {
                            "4",
                            ".NET Bot Black Sweatshirt",
                            "12.00",
                            "/images/products/4.png",
                            "2",
                            "2",
                            "15"});
#line 89
  testRunner.Then("the GetByPage response is verified for the following field", ((string)(null)), table12, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
