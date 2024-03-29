import 'package:jwt_decoder/jwt_decoder.dart';
import 'package:mobile/utils/token_store.dart';

class UserManager {
  static String? _fullName;
  static String? _userId ;

  static Future<String?> getFullNameAsync() async {
    if (_fullName == null) {
      Map<String, dynamic> decodedToken =
          JwtDecoder.decode(TokenManager.getToken()!);
      _fullName = decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
      _userId = decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    }

    return _fullName;
  }

  static String? getUserId() {
    return _userId;
  }

  static void removeCredentials() {
    _fullName = null;
    _userId = null;
  }
}
