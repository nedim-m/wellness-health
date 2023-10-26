import 'package:desktop/models/category.dart';
import 'package:desktop/providers/base_provider.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class CategoryProvider extends BaseProvider<Category> {
  CategoryProvider() : super("Category");

  @override
  Category fromJson(data) {
    return Category.fromJson(data);
  }

  Future<bool> delete(int id) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http.delete(uri, headers: headers);

    try {
      if (isValidResponse(response)) {
        var data = jsonDecode(response.body);
        return data;
      } else {
        throw Exception("Unknown error");
      }
    } catch (e) {
      return false;
    }
  }
}
