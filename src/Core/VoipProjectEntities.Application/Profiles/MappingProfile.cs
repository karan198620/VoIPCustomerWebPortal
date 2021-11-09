using AutoMapper;
using VoipProjectEntities.Application.Features.AgentCustomers.Commands.CreateAgentCustomer;
using VoipProjectEntities.Application.Features.AgentCustomers.Commands.UpdateAgentCustomer;
using VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomerDetail;
using VoipProjectEntities.Application.Features.AgentCustomers.Queries.GetAgentCustomersList;
using VoipProjectEntities.Application.Features.BalanceCustomers.Commands.CreateBalanceCustomer;
using VoipProjectEntities.Application.Features.BalanceCustomers.Commands.UpdateBalanceCustomer;
using VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomerDetail;
using VoipProjectEntities.Application.Features.BalanceCustomers.Queries.GetBalanceCustomersList;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.CreateCallRecordingAgent;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Commands.UpdateCallRecordingAgent;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCalllRecordingAgentDetail;
using VoipProjectEntities.Application.Features.CallRecordingAgents.Queries.GetCallRecordingAgentsList;
using VoipProjectEntities.Application.Features.Categories.Commands.CreateCateogry;
using VoipProjectEntities.Application.Features.Categories.Queries.GetCategoriesList;
using VoipProjectEntities.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using VoipProjectEntities.Application.Features.Customers.Commands.CreateCustomer;
using VoipProjectEntities.Application.Features.Customers.Commands.UpdateCustomer;
using VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerById;
using VoipProjectEntities.Application.Features.Customers.Queries.GetCustomerList;
using VoipProjectEntities.Application.Features.DeviceAgents.Commands.CreateDeviceAgent;
using VoipProjectEntities.Application.Features.DeviceAgents.Commands.UpdateDeviceAgent;
using VoipProjectEntities.Application.Features.DeviceAgents.Queries.GetDeviceAgentList;
using VoipProjectEntities.Application.Features.Events.Commands.CreateEvent;
using VoipProjectEntities.Application.Features.Events.Commands.UpdateEvent;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventDetail;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventsExport;
using VoipProjectEntities.Application.Features.Events.Queries.GetEventsList;
using VoipProjectEntities.Application.Features.Menu.Commands.CreateMenu;
using VoipProjectEntities.Application.Features.Menu.Queries.GetMenu;
using VoipProjectEntities.Application.Features.MenuAccesses.Commands.UpdateMenuAccess;
using VoipProjectEntities.Application.Features.Orders.Queries.GetOrdersForMonth;
using VoipProjectEntities.Application.Features.Settings.Commands.CreateSetting;
using VoipProjectEntities.Application.Features.Settings.Commands.UpdateSetting;
using VoipProjectEntities.Application.Features.Settings.Queries.GetSettingDetail;
using VoipProjectEntities.Application.Features.Settings.Queries.GetSettingsList;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.CreateSubscriptionCustomer;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Commands.UpdateSubscriptionCustomer;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerDetail;
using VoipProjectEntities.Application.Features.SubscriptionCustomers.Queries.GetSubscriptionCustomerList;
using VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.CreateTrialBalanceCustomer;
using VoipProjectEntities.Application.Features.TrialBalanceCustomers.Commands.UpdateTrialBalanceCustomer;
using VoipProjectEntities.Application.Features.TrialBalanceCustomers.Queries.GetTrialBalanceCustomerList;
using VoipProjectEntities.Domain.Entities;

namespace VoipProjectEntities.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();

            CreateMap<Customer, CreateCustomerCommand>();
            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerDetailVm>().ReverseMap();

            CreateMap<Customer, CustomerListVm>().ConvertUsing<CustomerVmCustomMapper>();

            CreateMap<MenuAccess, CreateMenuCommand>();
            CreateMap<MenuAccess, CreateMenuDto>();
            CreateMap<MenuAccess, UpdateMenuCommand>().ReverseMap();
            CreateMap<MenuAccess, MenuListVm>().ConvertUsing<MenuVmCustomMapper>();

            CreateMap<DeviceAgent, CreateDeviceAgentCommand>().ReverseMap();
            CreateMap<DeviceAgent, UpdateDeviceAgentCommand>().ReverseMap();
            CreateMap<DeviceAgent, DeviceAgentListVm>().ConvertUsing<DeviceAgentVmCustomMapper>();           

            CreateMap<TrailBalanceCustomer, TrailBalanceCustomerListVm>().ConvertUsing<TrailBalanceCustomerVmCustomMapper>();
            CreateMap<TrailBalanceCustomer, CreateTrailBalanceCustomerCommand>().ReverseMap();
            CreateMap<TrailBalanceCustomer, UpdateTrailBalanceCustomerCommand>().ReverseMap();

            CreateMap<AgentCustomer, AgentCustomerListVm>().ConvertUsing<AgentCustomerVmCustomMapper>();
            CreateMap<AgentCustomer, CreateAgentCustomerCommand>().ReverseMap();
            CreateMap<AgentCustomer, UpdateAgentCustomerCommand>().ReverseMap();
            CreateMap<AgentCustomer, AgentCustomerDetailVm>().ReverseMap();        

            CreateMap<Setting, SettingsListVm>().ConvertUsing<SettingVmCustomMapper>();
            CreateMap<Setting, SettingDetailVm>().ReverseMap();
            CreateMap<Setting, CreateSettingCommand>().ReverseMap();
            CreateMap<Setting, UpdateSettingCommand>().ReverseMap();

            CreateMap<SubscriptionCustomer, CreateSubscriptionCustomerCommand>().ReverseMap();
            CreateMap<SubscriptionCustomer, SubscriptionCustomersListVm>().ConvertUsing<SubscriptionCustomerVmCustomMapper>();
            CreateMap<SubscriptionCustomer, SubscriptionCustomerDetailVm>().ReverseMap();
            CreateMap<SubscriptionCustomer, UpdateSubscriptionCustomerCommand>().ReverseMap();

            CreateMap<BalanceCustomer, BalanceCustomerListVm>().ConvertUsing<BalanceCustomerVmCustomMapper>();
            CreateMap<BalanceCustomer, CreateBalanceCustomerCommand>().ReverseMap();
            CreateMap<BalanceCustomer, UpdateBalanceCustomerCommand>().ReverseMap();
            CreateMap<BalanceCustomer, BalanceCustomerDetailVm>().ReverseMap();

            CreateMap<CallRecordingAgent, CallRecordingAgentListVm>().ConvertUsing<CallRecordingAgentVmCustomMapper>();
            CreateMap<CallRecordingAgent, CreateCallRecordingAgentCommand>().ReverseMap();
            CreateMap<CallRecordingAgent, UpdateCallRecordingAgentCommand>().ReverseMap();
            CreateMap<CallRecordingAgent, CallRecordingAgentDetailVm>().ReverseMap();
        }
    }
}
