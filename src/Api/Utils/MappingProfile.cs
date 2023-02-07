using AutoMapper;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.ProductTracking;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Api.DTO.Settings;
using ProductTracking.Core.DTO;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Entities.Settings;
using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Api.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Office, OfficeListDTO>().ReverseMap();
        CreateMap<Office, OfficeRequestDTO>().ReverseMap();
        CreateMap<Office, OfficeResponseDTO>().ReverseMap();

        //CreateMap<User, UserRegisterDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, UserRequestDTO>().ReverseMap();
        CreateMap<User, UserResponseDTO>().ReverseMap();
        CreateMap<Role, RoleRequestDTO>().ReverseMap();
        CreateMap<Role, RoleResponseDTO>().ReverseMap();
        CreateMap<Role, RoleListDTO>().ReverseMap();
        CreateMap<Role, UserRoleRequestDTO>().ReverseMap();
        CreateMap<Role, UserRoleResponseDTO>().ReverseMap();
        CreateMap<RoleModuleFunction, RoleModuleFunctionRequestDTO>().ReverseMap();
        CreateMap<UserModuleFunction, UserModuleFunctionRequestDTO>().ReverseMap();
        CreateMap<UserModuleFunction, UserModuleFunctionResponseDTO>().ReverseMap();
        CreateMap<ModuleFunction, User_ModuleFunctionResponseDTO>().ReverseMap();
        CreateMap<Role, user_RoleResponseDTO>().ReverseMap();
        CreateMap<ModuleFunction, Role_ModuleFunctionResponseDTO>().ReverseMap();
        CreateMap<RoleModuleFunction, RoleModuleFunctionResponseDTO>().ReverseMap();

        CreateMap<ModuleFunction, ModuleResponseDTO>().ReverseMap();
        CreateMap<Module, ModuleResponseDTO>().ReverseMap();
        CreateMap<Module, RoleModuleResponseDTO>().ReverseMap();
        CreateMap<Office, OfficeRequestDTO>().ReverseMap();
        CreateMap<Office, OfficeListDTO>().ReverseMap();
        CreateMap<Application, RoleApplicationResponseDTO>().ReverseMap();
        CreateMap<Application, ApplicationResponseDTO>().ReverseMap();
        CreateMap<ModuleFunction, ModuleFunctionResponseDTO>().ReverseMap();
        CreateMap<Module, UserModuleResponseDTO>().ReverseMap();
        CreateMap<Application, UserApplicationResponseDTO>().ReverseMap();
        CreateMap<User, OrganizationUserResponseDTO>().ReverseMap();



        //productTracking

        CreateMap<HeaderContactDetail, HeaderContactDetailListDTO>().ReverseMap();
        CreateMap<HeaderContactDetail, HeaderContactDetailRequestDTO>().ReverseMap();
        CreateMap<HeaderContactDetail, HeaderContactDetailResponseDTO>().ReverseMap();

        CreateMap<Container, ContainerDTO>().ReverseMap();
        CreateMap<Container, ContainerListDTO>().ReverseMap();
        CreateMap<Container, ContainerRequestDTO>().ReverseMap();
        CreateMap<Container, ContainerResponseDTO>().ReverseMap();

        CreateMap<ItemGroup, ItemGroupDTO>().ReverseMap();
        CreateMap<ItemGroup, ItemGroupListDTO>().ReverseMap();
        CreateMap<ItemGroup, ItemGroupRequestDTO>().ReverseMap();
        CreateMap<ItemGroup, ItemGroupResponseDTO>().ReverseMap();

        CreateMap<Item, ItemDTO>().ReverseMap();
        CreateMap<Item, ItemListDTO>().ReverseMap();
        CreateMap<Item, ItemRequestDTO>().ReverseMap();
        CreateMap<Item, ItemResponseDTO>().ReverseMap();

        CreateMap<Consignment, ConsignmentDTO>().ReverseMap();
        CreateMap<Consignment, ConsignmentListDTO>().ReverseMap();
        CreateMap<Consignment, ConsignmentRequestDTO>().ReverseMap();
        CreateMap<Consignment, ConsignmentResponseDTO>().ReverseMap();


        CreateMap<ConsignmentItem, ConsignmentItemListDTO>().ReverseMap();
        CreateMap<ConsignmentItem, ConsignmentItemRequestDTO>().ReverseMap();
        CreateMap<ConsignmentItem, ConsignmentItemResponseDTO>().ReverseMap();

        CreateMap<Checkpoint, CheckpointListDTO>().ReverseMap();
        CreateMap<Checkpoint, CheckpointRequestDTO>().ReverseMap();
        CreateMap<Checkpoint, CheckpointResponseDTO>().ReverseMap();
        CreateMap<User, CheckPointUserRequestDTO>().ReverseMap();

        CreateMap<Checkpoint, CheckpointDTO>().ReverseMap();
        CreateMap<Consignment, ContainerConsignmentRequestDTO>().ReverseMap();

        CreateMap<Package, PackageDTO>().ReverseMap();
        CreateMap<Package, PackageListDTO>().ReverseMap();
        CreateMap<Package, PackageRequestDTO>().ReverseMap();
        CreateMap<Package, PackageResponseDTO>().ReverseMap();

       CreateMap<ContainerConsignment,ContainerConsignmentRequestDTO>().ReverseMap();
        CreateMap<ContainerConsignment, ContainerConsignmentListDTO>().ReverseMap();
        CreateMap<ContainerConsignment, ContainerConsignmentResponseDTO>().ReverseMap();

        CreateMap<ContainerConsignment, SearchConsignmentResponseDTO>().ReverseMap();


        CreateMap<Container, ContainerExcellDTO>().ReverseMap();
        CreateMap<ContainerConsignment, ContainerConsignmentExcellDTO>().ReverseMap();
        CreateMap<Consignment, ConsignmentExcellDTO>().ReverseMap();
        CreateMap<ConsignmentItem, ConsignmentItemsExcellDTO>().ReverseMap();
        CreateMap<Item, ItemExcellDTO>().ReverseMap();


    }
}
