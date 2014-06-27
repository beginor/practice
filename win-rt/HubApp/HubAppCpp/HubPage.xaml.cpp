//
// HubPage.xaml.cpp
// Implementation of the HubPage class.
//

#include "pch.h"
#include "HubPage.xaml.h"
#include "SectionPage.xaml.h"
#include "ItemPage.xaml.h"

using namespace HubAppCpp;
using namespace HubAppCpp::Common;
using namespace HubAppCpp::Data;

using namespace concurrency;
using namespace Platform;
using namespace Windows::ApplicationModel::Resources;
using namespace Windows::Foundation::Collections;
using namespace Windows::Graphics::Display;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Navigation;

// The Hub Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

HubPage::HubPage()
{
	InitializeComponent();
	
	DisplayInformation::AutoRotationPreferences = DisplayOrientations::Portrait;
	NavigationCacheMode = Navigation::NavigationCacheMode::Required;

	_resourceLoader = ResourceLoader::GetForCurrentView(L"Resources");

	auto navigationHelper = ref new Common::NavigationHelper(this);
	navigationHelper->LoadState += ref new LoadStateEventHandler(this, &HubPage::NavigationHelper_LoadState);
	navigationHelper->SaveState += ref new SaveStateEventHandler(this, &HubPage::NavigationHelper_SaveState);

	SetValue(_defaultViewModelProperty, ref new Platform::Collections::Map<String^, Object^>(std::less<String^>()));
	SetValue(_navigationHelperProperty, navigationHelper);
}

DependencyProperty^ HubPage::_defaultViewModelProperty = DependencyProperty::Register(
	"DefaultViewModel",
	IObservableMap<String^, Object^>::typeid, 
	HubPage::typeid, 
	nullptr);

IObservableMap<String^, Object^>^ HubPage::DefaultViewModel::get()
{
	return safe_cast<IObservableMap<String^, Object^>^>(GetValue(_defaultViewModelProperty));	
}

DependencyProperty^ HubPage::_navigationHelperProperty = DependencyProperty::Register(
	"NavigationHelper",
	NavigationHelper::typeid,
	HubPage::typeid,
	nullptr);

NavigationHelper^ HubPage::NavigationHelper::get()
{
	return safe_cast<Common::NavigationHelper^>(GetValue(_navigationHelperProperty));
}

void HubPage::OnNavigatedTo(NavigationEventArgs^ e)
{
	NavigationHelper->OnNavigatedTo(e);
}

void HubPage::OnNavigatedFrom(NavigationEventArgs^ e)
{
	NavigationHelper->OnNavigatedFrom(e);
}

/// <summary>
/// Populates the page with content passed during navigation. Any saved state is also
/// provided when recreating a page from a prior session.
/// </summary>
/// <param name="sender">
/// The source of the event; typically <see cref="NavigationHelper"/>.
/// </param>
/// <param name="e">Event data that provides both the navigation parameter passed to
/// <see cref="Frame->Navigate(Type, Object)"/> when this page was initially requested and
/// a dictionary of state preserved by this page during an earlier
/// session. The state will be null the first time a page is visited.</param>
void HubPage::NavigationHelper_LoadState(Object^ sender, LoadStateEventArgs^ e)
{
	(void)sender;	// Unused parameter
	(void)e;		// Unused parameter

	SampleDataSource::GetGroups().then([this](IIterable<SampleDataGroup^>^ sampleDataGroups)
	{
		DefaultViewModel->Insert("Groups", sampleDataGroups);
	}, task_continuation_context::use_current());
}

/// <summary>
/// Preserves state associated with this page in case the application is suspended or the
/// page is discarded from the navigation cache. Values must conform to the serialization
/// requirements of <see cref="SuspensionManager.SessionState"/>.
/// </summary>
/// <param name="sender">
/// The source of the event; typically <see cref="NavigationHelper"/>.
/// </param>
/// <param name="e">
/// Event data that provides an empty dictionary to be populated with serializable state.
/// </param>
void HubPage::NavigationHelper_SaveState(Object^ sender, SaveStateEventArgs^ e)
{
	// TODO: Save the unique state of the page here.
}

/// <summary>
/// Shows the details of a clicked group in the <see cref="SectionPage"/>.
/// </summary>
void HubPage::GroupSection_ItemClick(Object^ sender, ItemClickEventArgs ^e)
{
	auto groupId = safe_cast<SampleDataGroup^>(e->ClickedItem)->UniqueId;
	if (!Frame->Navigate(SectionPage::typeid, groupId))
	{
		throw ref new FailureException(_resourceLoader->GetString(L"NavigationFailedExceptionMessage"));
	}
}

/// <summary>
/// Invoked when an item within a section is clicked.
/// </summary>
void HubPage::ItemView_ItemClick(Object^ sender, ItemClickEventArgs ^e)
{
	auto itemId = safe_cast<SampleDataItem^>(e->ClickedItem)->UniqueId;
	if (!Frame->Navigate(ItemPage::typeid, itemId))
	{
		throw ref new FailureException(_resourceLoader->GetString(L"NavigationFailedExceptionMessage"));
	}
}
