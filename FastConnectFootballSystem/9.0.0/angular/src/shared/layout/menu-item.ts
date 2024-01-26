export class MenuItem {
  id: number;
  parentId: number;
  label: string;
  route: string;
  icon: string;
  permissionName: string;
  isActive?: boolean;
  isCollapsed?: boolean;
  children: MenuItem[];

  constructor(
    label: string,
    route: string,
    icon: string,
    children: MenuItem[] = null,
    permissionName: string = null
  ) {
    this.label = label;
    this.route = route;
    this.icon = icon;
    this.permissionName = permissionName;
    this.children = children;
  }
}
