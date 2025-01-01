using playwright_newintegrationtests.PageObjects;

namespace playwright_newintegrationtests.PlaywrightCode
{
    public class RepeatablePlaywrightMethods : PageTest
    {
        //// Runner Settings.
        //// These could be set by environment variables or other input mechanisms.
        //// They are hard-coded here to keep the example project simple.
        //private static readonly bool UseUltrafastGrid = true;

        //// Test control inputs to read once and share for all tests
        //private static string? ApplitoolsApiKey;
        //private static bool Headless;

        //// Test-specific objects
        //private static IPlaywright Playwright;
        //private static IBrowser Browser;
        //private IBrowserContext Context;
        //private IPage Page;
        //// private Eyes Eyes;

        public static async Task<ILocator> TestReturn(IPage Page, string elementname)
        {
            var extelement = Page.GetByText(elementname);
                extelement.WaitForAsync();
                extelement.HighlightAsync();
            
           return extelement;  
        }

        public static async Task TestImgs(IPage Page, string elementname)
        {
            //using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            //using var browser = await Microsoft.Playwright.Playwright.CreateAsync();
           // var ipage = await browser.NewPageAsync();
            //using var playwright = await Playwright.ageaywright.CreateAsync();

 
        }

        public static async Task DatetimeAction(IPage Page, DateTime actiontimepicker, string actionpath)
        {
            var dateFormat = string.Format("dd/MMMM/yyyy hh:mm:ss tt");

            var timeFormathh = string.Format("hh");
            var timeFormatmm = string.Format("mm");
            var timeFormatss = string.Format("ss");

            var timeFormattt = string.Format("tt");

            if (actiontimepicker.ToString(timeFormathh) == "12") { await Page.Locator(actionpath).Nth(0).ClickAsync(new() { Timeout = 10_000 }); }
            else { await Page.Locator(actionpath).Nth(Convert.ToInt16(actiontimepicker.ToString(timeFormathh))).ClickAsync(new() { Timeout = 10_000 }); }

            await Page.WaitForTimeoutAsync(1000);
            await Page.Locator(actionpath).Nth(Convert.ToInt16(Convert.ToInt16(actiontimepicker.ToString(timeFormatmm)) + 12)).ClickAsync(new() { Timeout = 10_000 });
            await Page.WaitForTimeoutAsync(1000);
            await Page.Locator(actionpath).Nth(Convert.ToInt16(Convert.ToInt16(actiontimepicker.ToString(timeFormatss)) + 72)).ClickAsync(new() { Timeout = 10_000 });
            await Page.WaitForTimeoutAsync(1000);

            if (actiontimepicker.ToString(timeFormattt) == "AM") { await Page.Locator(actionpath).Nth(132).ClickAsync(new() { Timeout = 10_000 }); }
            else { await Page.Locator(actionpath).Nth(133).ClickAsync(new() { Timeout = 10_000 }); }
        }

        public static async Task<ILocator> AccessLandingPage_GetByText(IPage Page, string elementname)
        {
            PlaywrightTest repeatableplaywrightMethods = new();
            await repeatableplaywrightMethods.Expect(Page.GetByText(elementname))
                .ToBeVisibleAsync(new() { Timeout = 10_000 });

            //await Page.GetByText(elementname).WaitForAsync();
            if (await Page.GetByText(elementname).IsVisibleAsync(new() { Timeout = 10_000 }))
            {
                await Page.GetByText(elementname).HighlightAsync();

                Page.WaitForTimeoutAsync(2000);
                return Page.GetByText(elementname);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task TesterSignOut(IPage Page, string testerid)
        {
            await TestElement_GetByText(Page, testerid).GetResult().ClickAsync(new() { Timeout = 10_000 });
            await TestElement_GetByText(Page, "Sign out").GetResult().ClickAsync(new() { Timeout = 10_000 });
            await TestButton_GetByRole(Page, "Yes").GetResult().ClickAsync(new() { Timeout = 10_000 });
            //await UserIdentification(Page, testerid, instructions.click);

            //await Page.GetByText(signoutinstruction).HighlightAsync(); //  "Sign out"
            //await Page.WaitForTimeoutAsync(1000);
            //await Page.GetByText(signoutinstruction).ClickAsync(); //  "Sign out"

            //await Page.GetByText("ICEPOR\\t.f.vtos01").ClickAsync();
            //await Page.GetByText("Sign out").ClickAsync();
            //await Page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).ClickAsync();

            await Page.WaitForTimeoutAsync(1000);
        }
        
        public static async Task<IElementHandle> TestWaitForSelectorAsync(IPage Page, string elementname)
        {
            Page.WaitForTimeoutAsync(2000);
            return await Page.WaitForSelectorAsync(elementname);
        } 
        
        public static async Task<ILocator> UserInitials(IPage Page, string testerinitials)
        {
            await Page.GetByRole(AriaRole.Button, new() { Name = testerinitials }).WaitForAsync(new() { Timeout = 10_000 });

            if (Page.GetByRole(AriaRole.Button, new() { Name = testerinitials }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByRole(AriaRole.Button, new() { Name = testerinitials }).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.GetByRole(AriaRole.Button, new() { Name = testerinitials });
            }
            return Page.GetByText(pagehometab.text_home);
        }
    
        public static async Task<ILocator> UserIdentification(IPage Page, string testerid)
        {
            await Page.GetByText(testerid).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByText(testerid).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByText(testerid).HighlightAsync();
                Page.WaitForTimeoutAsync(2000);
                return Page.GetByText(testerid);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task TestLoad_WaitForSelector(IPage Page, string waitforselector)
        {
            await Page.WaitForSelectorAsync(waitforselector);
        }

        public static async Task<ILocator> TestExpect_GetByText(IPage Page, string elementname)
        {
            await Page.GetByText(elementname).WaitForAsync(new() { Timeout = 10_000 });
            
            if (Page.GetByText(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByText(elementname).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.GetByText(elementname);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestCell_GetByRole(IPage Page, string cellname)
        {
            await Page.GetByRole(AriaRole.Cell, new() { Name = cellname }).WaitForAsync(new() { Timeout = 10_000 });

            if (Page.GetByRole(AriaRole.Cell, new() { Name = cellname }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByRole(AriaRole.Cell, new() { Name = cellname }).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.GetByRole(AriaRole.Cell, new() { Name = cellname });
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestTab_GetByRole(IPage Page, string tabname)
        {
            await Page.GetByRole(AriaRole.Tab, new() { Name = tabname }).WaitForAsync(new() { Timeout = 10_000 });

            if (Page.GetByRole(AriaRole.Tab, new() { Name = tabname }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByRole(AriaRole.Tab, new() { Name = tabname }).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.GetByRole(AriaRole.Tab, new() { Name = tabname });
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestTextBox_GetByPlaceholder(IPage Page, string elementname)
        {
            await Page.GetByPlaceholder(elementname).WaitForAsync(new() { Timeout = 10_000 });

            if (Page.GetByPlaceholder(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                //  await Page.GetByPlaceholder(elementname).ClickAsync(new LocatorClickOptions() { Trial = true });
                await Page.GetByPlaceholder(elementname).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.GetByPlaceholder(elementname);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestTextBox_GetByLabel(IPage Page, string elementname)
        {
            await Page.GetByLabel(elementname).WaitForAsync(new() { Timeout = 10_000 });

            if (Page.GetByLabel(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                //  await Page.GetByPlaceholder(elementname).ClickAsync(new LocatorClickOptions() { Trial = true });
                await Page.GetByLabel(elementname).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.GetByLabel(elementname);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestElement_LocatorGetByPlaceholder(IPage Page, ILocator ilocatorelement)//, string elemenvalue, string elementinstruction)
        {
            await ilocatorelement.WaitForAsync(new() { Timeout = 10_000 });
            if (ilocatorelement.IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await ilocatorelement.HighlightAsync();
                return ilocatorelement;
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestButton_GetByRole(IPage Page, string elementname)
        {
            await Page.GetByRole(AriaRole.Button, new() { Name = elementname }).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByRole(AriaRole.Button, new() { Name = elementname }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByRole(AriaRole.Button, new() { Name = elementname }).HighlightAsync();
                await Page.WaitForTimeoutAsync(2000);
                return Page.GetByRole(AriaRole.Button, new() { Name = elementname });
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestLink_GetByRole(IPage Page, string elementname)
        {
            await Page.GetByRole(AriaRole.Link, new() { Name = elementname }).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByRole(AriaRole.Link, new() { Name = elementname }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByRole(AriaRole.Link, new() { Name = elementname }).HighlightAsync();
                await Page.WaitForTimeoutAsync(2000);
                return Page.GetByRole(AriaRole.Link, new() { Name = elementname });
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestTextBox_GetByRole(IPage Page, string elementname)
        {
            await Page.GetByRole(AriaRole.Textbox, new() { Name = elementname }).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByRole(AriaRole.Textbox, new() { Name = elementname }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByRole(AriaRole.Textbox, new() { Name = elementname }).HighlightAsync();
                return Page.GetByRole(AriaRole.Textbox, new() { Name = elementname });
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestElement_GetByText(IPage Page, string elementname)
        {
            await Page.GetByText(elementname).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByText(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByText(elementname).HighlightAsync();
                Page.WaitForTimeoutAsync(2000);
                return Page.GetByText(elementname); 
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestElement_GetByLabel(IPage Page, string elementname)
        {
            await Page.GetByLabel(elementname).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByLabel(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByLabel(elementname).HighlightAsync();
                await Page.WaitForTimeoutAsync(2000);
                return Page.GetByLabel(elementname);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator>  TestElementExactTrue_GetByText(IPage Page, string elementname)
        {
            await Page.GetByText(elementname, new() { Exact = true }).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByText(elementname, new() { Exact = true }).IsVisibleAsync().Result)
            {
                await Page.GetByText(elementname, new() { Exact = true }).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.GetByText(elementname, new() { Exact = true });
            }
            return Page.GetByText(pagehometab.text_home);
        }

       // public async Task<bool> ISLoggedin() => await Page.Locator(selector: ".user-initials").IsVisibleAsync();
       // var locator = Page.Locator(".title"); await Expect(locator).ToHaveTextAsync("Welcome, Test User");

        public static async Task<ILocator> locator_GetByText(IPage Page, string elementname)
        {
            await Page.GetByText(elementname, new() { Exact = true }).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByText(elementname, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByText(elementname, new() { Exact = true }).HighlightAsync();
                return Page.GetByText(elementname, new() { Exact = true });
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestElement_Locator(IPage Page, string elementname)
        {
            await Page.Locator(elementname).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.Locator(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.Locator(elementname).HighlightAsync();
                return Page.Locator(elementname);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestElement_ILocator(IPage Page, ILocator ielement)
        {
            await ielement.WaitForAsync(new() { Timeout = 10_000 });
            if (ielement.IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await ielement.HighlightAsync();
                return ielement;
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> Test_ILocator(IPage Page, ILocator ielement)
        {
            await ielement.WaitForAsync(new() { Timeout = 10_000 });
            if (ielement.IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await ielement.HighlightAsync();
                return ielement;
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestTextBox_LocatorGetByRole(IPage Page, string elementname)
        {
            await Page.Locator(elementname).GetByRole(AriaRole.Textbox).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.Locator(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.Locator(elementname).GetByRole(AriaRole.Textbox).HighlightAsync();
                return Page.Locator(elementname).GetByRole(AriaRole.Textbox);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestButton_LocatorGetByRole(IPage Page, ILocator locatorelement)
        {
            await locatorelement.GetByRole(AriaRole.Button).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByRole(AriaRole.Button).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await locatorelement.GetByRole(AriaRole.Button).HighlightAsync();
                return locatorelement.GetByRole(AriaRole.Button);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestElement_GetByTitle(IPage Page, string elementname, string elementlocation)
        {
            await Page.GetByTitle(elementname).Locator(elementlocation).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByTitle(elementname).Locator(elementlocation).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByTitle(elementname).Locator(elementlocation).HighlightAsync();
                return Page.GetByTitle(elementname).Locator(elementlocation);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestClickElement_Nth_Locator(IPage Page, string elementname, int nth)
        {
            Page.Locator(elementname).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.Locator(elementname).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                //await Page.Locator(elementname, new() { Exact = true }).WaitForAsync();
                //await Page.Locator(elementname, new() { Exact = true }).HighlightAsync();

                //switch (elementinstruction)
                //{
                //    case instructions.click: { await Page.Locator(elementname, new() { Exact = true }).ClickAsync(); break; }
                //    case "HOVER": { await Page.Locator(elementname, new() { Exact = true }).HoverAsync(); break; }
                //    default: { break; }
                //}
                await Page.Locator(elementname).HighlightAsync();
                await Page.WaitForTimeoutAsync(1000);
                return Page.Locator(elementname);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestID_GetTestId_Nth(IPage Page, string elementname, int elementindex)
        {
            await Page.GetByTestId(elementname).Nth(elementindex).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.GetByTestId(elementname).Nth(elementindex).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.GetByTestId(elementname).Nth(elementindex).HighlightAsync();
                return Page.GetByTestId(elementname).Nth(elementindex);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<ILocator> TestElement_LocatorGetByText(IPage Page, string elementname, string elementtext)
        {
            await Page.Locator(elementname).GetByText(elementtext).WaitForAsync(new() { Timeout = 10_000 });
            if (Page.Locator(elementname).GetByText(elementtext).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await Page.Locator(elementname).GetByText(elementtext).HighlightAsync();
                return Page.Locator(elementname).GetByText(elementtext);
            }
            return Page.GetByText(pagehometab.text_home);
        }

        //public static async Task TestElement_GetByText(IPage Page, string elementtext, string elementinstruction)
        //{
        //    await Page.GetByText(elementtext).HighlightAsync();
        //    await Page.WaitForTimeoutAsync(1000);
        //    await Page.GetByText(elementtext).HoverAsync();
        //    await Page.WaitForTimeoutAsync(1000);
        //}

        //public static async Task TestClickElement_GetByText(IPage Page, string elementtext)
        //{
        //    await Page.GetByText(elementtext).HighlightAsync();
        //    await Page.WaitForTimeoutAsync(1000);
        //    await Page.GetByText(elementtext).ClickAsync();
        //    await Page.WaitForTimeoutAsync(1000);
        //}

        //public static async Task TestClickElement_dropdown(IPage Page, ILocator dropdownfirst, string dropdowntext)
        //{
        //    //    await Page.ClickAsync(dropdownfirst);
        //    await Page.WaitForTimeoutAsync(1000);
        //    await Page.ClickAsync(selector: dropdowntext);
        //    await Page.WaitForTimeoutAsync(1000);
        //}

        public static async Task<ILocator> TestElement_Selectdropdown(IPage Page, string selecttext, int selectidx)
        {
            if (Page.Locator(selector: selecttext).Nth(selectidx).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                var selectdropdown = Page.Locator(selector: selecttext).Nth(selectidx);
                await selectdropdown.Nth(selectidx).WaitForAsync(new() { Timeout = 10_000 });
                await selectdropdown.HighlightAsync();
                return selectdropdown;
            }
            return Page.GetByText(pagehometab.text_home);
        }

        public static async Task<IElementHandle> TestElement_Check(IPage Page, string elementname) // Check Suspended Button 
        {
            var isSuspendedToggle = await Page.QuerySelectorAsync(elementname);
            if (isSuspendedToggle != null)
            {
                isSuspendedToggle.HoverAsync();
            }
            return isSuspendedToggle; 
        }

    public static async Task TestDatepicker_Action(IPage Page, ILocator ielement, ILocator ilocatorelement, DateTime dateinput)
        {
            //await Page.GetByRole(AriaRole.Button, new() { Name = elementname }).ClickAsync(new LocatorClickOptions() { Trial = true });

            var dateFormat = string.Format(elementdateformat.dateFormat);

            var dateFormatdd = string.Format(elementdateformat.dateFormatdd);
            var dateFormatMM = string.Format(elementdateformat.dateFormatMM);
            var dateFormatMMMM = string.Format(elementdateformat.dateFormatMMMM);
            var dateFormatyyyy = string.Format(elementdateformat.dateFormatyyyy);

            var timeFormathh = string.Format(elementdateformat.timeFormathh);
            var timeFormatmm = string.Format(elementdateformat.timeFormatmm);
            var timeFormatss = string.Format(elementdateformat.timeFormatss);

            var timeFormattt = string.Format(elementdateformat.timeFormattt);

            var datedd = dateinput.ToString(dateFormatdd).TrimStart('0');
            var dateMM = dateinput.ToString(dateFormatMM).TrimStart('0');
            var dateMMMM = dateinput.ToString(dateFormatMMMM).Substring(0, 3);
            var dateccyy = dateinput.ToString(dateFormatyyyy);
            var dateHH = dateinput.ToString(timeFormathh);
            var datemm = dateinput.ToString(timeFormatmm);
            var datess = dateinput.ToString(timeFormatss);
            var datett = dateinput.ToString(timeFormattt);

            await Test_ILocator(Page, ielement).GetResult().ClickAsync(new() { Timeout = 10_000 });
            await Test_ILocator(Page, ilocatorelement).GetResult().ClickAsync(new() { Timeout = 10_000 });

            await TestElement_LocatorGetByPlaceholder(Page, ilocatorelement).GetResult().FillAsync(dateinput.ToString(dateFormat), new() { Timeout = 10_000 });
            await TestButton_GetByRole(Page, dateccyy).GetResult().ClickAsync(new() { Timeout = 10_000 });
            await TestElement_GetByText(Page, dateccyy).GetResult().ClickAsync(new() { Timeout = 10_000 });
            await TestButton_GetByRole(Page, DateTime.Now.ToString(dateFormatMMMM).Remove(3)).GetResult().ClickAsync();
            await TestElement_GetByText(Page, dateMMMM.Remove(3)).GetResult().ClickAsync(new() { Timeout = 10_000 });
            await TestElement_GetByTitle(Page, dateMM + @"/" + datedd.TrimStart('0') + @"/", "div").GetResult().ClickAsync(new() { Timeout = 10_000 });
 
            await RepeatableMethods.DatetimeAction(Page, dateinput, elementsobjects.actionpath);
            await TestButton_GetByRole(Page, "Ok").GetResult().ClickAsync(new() { Timeout = 10_000 });
        }
    }
}


