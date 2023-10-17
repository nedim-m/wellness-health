class RoleManager {
  static bool? _isAdmin;

  static bool? getRole() {
    return _isAdmin;
  }

  static void saveIsAdmin(String roleId) {
    if (roleId == "1") {
      _isAdmin = true;
    }
  }

  static void removeIsAdmin() {
    _isAdmin = null;
  }
}
