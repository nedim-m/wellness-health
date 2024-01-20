import 'dart:convert';

import 'package:mobile/models/user.dart';
import 'package:mobile/providers/base_provider.dart';
import 'package:mobile/utils/token_store.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<dynamic> register(
      String firstName,
      String lastName,
      String email,
      String userName,
      String password,
      String confrimPassword,
      String phone) async {
    var url = "${baseUrl}Auth/register";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": confrimPassword,
      "phone": phone
    });

    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<bool> login(String username, String password) async {
    var url = "${baseUrl}Auth/login";
    var uri = Uri.parse(url);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "userName": username,
      "password": password,
      "desktop": false,
    });

    var response = await http!.post(uri,
        headers: {'Content-Type': 'application/json'}, body: jsonRequest);

    try {
      if (isValidResponse(response)) {
        var data = jsonDecode(response.body);
        TokenManager.saveToken(data['token']);
        return true;
      } else {
        throw Exception("Unknown error");
      }
    } catch (e) {
      return false;
    }
  }
}
