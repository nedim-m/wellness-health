import 'dart:convert';

import 'package:mobile/models/user.dart';
import 'package:mobile/providers/base_provider.dart';
import 'package:mobile/utils/token_store.dart';
import 'package:mobile/utils/user_store.dart';

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
    String confirmPassword,
    String phone,
  ) async {
    var url = "${baseUrl}Auth/register";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token ?? '');

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": confirmPassword,
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

  Future<User> getById() async {
    int id = int.parse(UserManager.getUserId()!);
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http!.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> updateUser(
      String firstName,
      String lastName,
      String email,
      String userName,
      String password,
      String confrimPassword,
      String phone) async {
    int id = int.parse(UserManager.getUserId()!);
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": confrimPassword,
      "roleId": 3,
      "phone": phone
    });

    var response = await http!.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> forgotPassword(
    String userName,
    String email,
  ) async {
    var url = "$baseUrl$endpoint/reset";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token ?? '');

    var jsonRequest =
        jsonEncode(<String, dynamic>{"userName": userName, "email": email});

    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = response.body;
      return data;
    } else {
      throw Exception("Unknown error");
    }
  }
}
