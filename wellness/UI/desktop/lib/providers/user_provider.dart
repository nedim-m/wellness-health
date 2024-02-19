import 'dart:convert';

import 'package:desktop/providers/base_provider.dart';
import 'package:desktop/utils/role_store.dart';
import 'package:http/http.dart' as http;

import '../models/user.dart';
import '../utils/token_store.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<dynamic> updateUser(
    int id,
    String firstName,
    String lastName,
    String email,
    String userName,
    String phone,
    String password,
  ) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": password,
      "roleId": 3,
      "phone": phone,
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> addUser(String firstName, String lastName, String email,
      String userName, String phone, String password) async {
    var url = "${baseUrl}Auth/register";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": password,
      "phone": phone
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> addWorker(
      String firstName,
      String lastName,
      String email,
      String userName,
      String phone,
      String password,
      int roleId,
      String picture,
      bool status) async {
    var url = "$baseUrl$endpoint";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": password,
      "picture": picture,
      "roleId": roleId,
      "phone": phone,
      "status": status
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> updateWorker(
      int id,
      String firstName,
      String lastName,
      String email,
      String userName,
      String phone,
      String password,
      int roleId,
      String picture,
      bool status) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": password,
      "picture": picture,
      "roleId": roleId,
      "phone": phone,
      "status": status
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

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
      "desktop": true,
    });

    var response = await http.post(uri,
        headers: {'Content-Type': 'application/json'}, body: jsonRequest);

    try {
      if (isValidResponse(response)) {
        var data = jsonDecode(response.body);
        TokenManager.saveToken(data['token']);
        RoleManager.saveIsAdmin(data['message']);
        return true;
      } else {
        throw Exception("Unknown error");
      }
    } catch (e) {
      return false;
    }
  }
}
