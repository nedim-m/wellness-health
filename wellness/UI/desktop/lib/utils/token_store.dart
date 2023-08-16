class TokenManager {
  static String? _token;

  static String? getToken() {
    return _token;
  }

  static void saveToken(String token) {
    _token = token;
  }

  static void removeToken() {
    _token = null;
  }
}
