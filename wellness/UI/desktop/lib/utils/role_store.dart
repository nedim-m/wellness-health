// ignore_for_file: avoid_print

import 'package:jwt_decoder/jwt_decoder.dart';

class RoleManager {
  static bool? _isAdmin;
  static String? _userId;

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

  static int getUserId() {
    if (_userId != null) {
      return int.tryParse(_userId!)!;
    }
    return -1;
  }

  static Future<void> setUserId(String token) async {
    try {
      Map<String, dynamic> decodedToken = JwtDecoder.decode(token);
      _userId = decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    } catch (e) {
      print('Greška prilikom dekodiranja tokena: $e');
    }
  }

  static void removeCredentials() {
    _isAdmin = null;
    _userId = null;
  }
}
