import 'package:mobile/models/membership_type.dart';
import 'package:mobile/providers/base_provider.dart';

class MembershipTypeProvider extends BaseProvider<MembershipType> {
  MembershipTypeProvider() : super("MembershipType");

  @override
  MembershipType fromJson(data) {
    return MembershipType.fromJson(data);
  }
}
